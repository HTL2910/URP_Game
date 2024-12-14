using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public AudioSource audioSource;//audio(click, pick up)...
    public AudioSource soundSource;//sound Game
    
    public AudioClip moneyPickClip;

    private void Start()
    {
        soundSource.Play();
    }
}
