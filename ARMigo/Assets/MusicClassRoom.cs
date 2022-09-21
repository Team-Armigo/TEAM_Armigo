using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
 public class MusicClassRoom : MonoBehaviour
 {
     private AudioSource _audioSource2;
     private void Awake()
     {
         DontDestroyOnLoad(transform.gameObject);
         _audioSource2 = GetComponent<AudioSource>();
     }
 
     public void PlayMusic()
     {
         if (_audioSource2.isPlaying) return;
         _audioSource2.Play();
     }
 
     public void StopMusic()
     {
        Debug.Log("실행");
         _audioSource2.Stop();
     }
 }