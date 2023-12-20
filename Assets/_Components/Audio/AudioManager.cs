using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }


    private AudioSource audioSource;
[SerializeField]
    private AudioClip construction;
    
    
    
    public AudioClip[] songs; // Array to hold your songs
    private int currentSongIndex = 0;
    private bool isPlaying = false;
    

    private void Awake() 
{ 
    // If there is an instance, and it's not me, delete myself.
    
    if (Instance != null && Instance != this) 
    { 
        Destroy(this); 
    } 
    else 
    { 
        Instance = this; 
    } 
}

private void Start()
{
    audioSource = GetComponent<AudioSource>();
    PlaySong();
}

public void PlayConstructionSound(){
    audioSource.PlayOneShot(construction);
}




private void Update()
{
    if (!isPlaying && Time.timeScale != 0)
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
public void PauseMusic()
{
    audioSource.Pause();
}

public void PlayMusic()
{
    audioSource.Play();
}
}
