using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomAudio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClass>().StopMusic();
        Debug.Log("Stop Music Done.");
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClassRoom>().PlayMusic();

    }

    // Update is called once per frame
    void Update()
    {
    }
}
