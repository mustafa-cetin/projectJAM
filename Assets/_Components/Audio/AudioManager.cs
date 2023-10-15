using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }


[SerializeField]
    private AudioClip construction;
    [SerializeField]
    private AudioClip[] musics;

[SerializeField]
    private AudioClip tutorial;

    private AudioSource audioSource;
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
private void Start() {
    audioSource=GetComponent<AudioSource>();
    audioSource.PlayOneShot(tutorial);
    StartCoroutine(startMusic());

}
IEnumerator startMusic(){

        yield return new WaitForSeconds(60f);
    foreach (var item in musics)
    {
        audioSource.clip=musics[0];
        audioSource.Play();
        yield return new WaitUntil(
        () => !audioSource.isPlaying 
              && Time.timeScale != 0 
        ); 
        yield return new WaitForSeconds(30f);
    }
}
public void PlayConstructionSound(){
    audioSource.PlayOneShot(construction);
}
}
