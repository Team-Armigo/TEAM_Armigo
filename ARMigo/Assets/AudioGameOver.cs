using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioGameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClassGame>().StopMusic();
        Debug.Log("Stop Music Done.");

    }

    // Update is called once per frame
    void Update()
    {
    }
}
