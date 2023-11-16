using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip[] songs; // Array to hold your songs
    private AudioSource audioSource;
    private int currentSongIndex = 0;
    private bool isPlaying = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlaySong();
    }

    private void Update()
    {
        if (!isPlaying)
        {
            StartCoroutine(PlayNextAfterDelay(audioSource.clip.length + 8f)); // Delay before playing the next song
            isPlaying = true;
        }
    }

    private void PlaySong()
    {
        audioSource.clip = songs[currentSongIndex];
        audioSource.Play();
    }

    private System.Collections.IEnumerator PlayNextAfterDelay(float delay)
    {
        Debug.Log("Current song is "+audioSource.clip);
        yield return new WaitForSeconds(delay);
        currentSongIndex = (currentSongIndex + 1) % songs.Length; // Loop back to the first song if at the end
        PlaySong();
        isPlaying = false;
    }
}
