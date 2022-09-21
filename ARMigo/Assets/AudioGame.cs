using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClassRoom>().StopMusic();
        //GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClassGame>().StopMusic();
        //GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClass>().StopMusic();

        Debug.Log("Stop Music2 Done.");
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClassGame>().PlayMusic();

    }

    // Update is called once per frame
    void Update()
    {

    }

    

}