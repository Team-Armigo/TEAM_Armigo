using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OkayAudio : MonoBehaviour
{
    private AudioSource _audioSource;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();

    }
    public void PlayMusic()
     {
         if (_audioSource.isPlaying) return;
         _audioSource.Play();
     }
 
     public void StopMusic()
     {
         _audioSource.Stop();
     }
}
