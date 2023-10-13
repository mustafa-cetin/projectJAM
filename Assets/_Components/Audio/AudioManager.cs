using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }


[SerializeField]
    private AudioClip construction;

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
}
public void PlayConstructionSound(){
    audioSource.PlayOneShot(construction);
}
}
