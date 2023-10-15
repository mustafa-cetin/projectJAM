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
    StartCoroutine(startMusic());

}
IEnumerator startMusic(){

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
