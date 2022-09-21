using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
 public class MusicClass : MonoBehaviour
 {
     private AudioSource _audioSource1;
     private void Awake()
     {
         DontDestroyOnLoad(transform.gameObject);
         _audioSource1 = GetComponent<AudioSource>();
     }
 
     public void PlayMusic()
     {
         if (_audioSource1.isPlaying) return;
         _audioSource1.Play();
     }
 
     public void StopMusic()
     {
         _audioSource1.Stop();
     }
 }