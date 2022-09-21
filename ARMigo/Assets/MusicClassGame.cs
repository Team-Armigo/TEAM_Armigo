using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
 public class MusicClassGame : MonoBehaviour
 {
     private AudioSource _audioSource3;
     private void Awake()
     {
         DontDestroyOnLoad(transform.gameObject);
         _audioSource3 = GetComponent<AudioSource>();
     }
 
     public void PlayMusic()
     {
         if (_audioSource3.isPlaying) return;
         _audioSource3.Play();

         Debug.Log("3번째 노래 실행");
     }
 
     public void StopMusic()
     {
         _audioSource3.Stop();
     }

    private void Stop_music()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClassRoom>().StopMusic();
    }
 }