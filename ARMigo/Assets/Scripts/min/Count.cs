using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Count : MonoBehaviour
{
    private int Timer = 0;
    public GameObject IMG_tutorial;
    public GameObject Num_A;
    public GameObject Num_B;
    public GameObject Num_C;
    public GameObject Num_GO;

    // Start is called before the first frame update
    void Start()
    {
        Timer = 0;

        IMG_tutorial.SetActive(false);
        Num_A.SetActive(false);
        Num_B.SetActive(false);
        Num_C.SetActive(false);
        Num_GO.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Timer == 0)
        {
            Time.timeScale = 0.0f;
        }
        if (Timer <= 1500)
        {
            Timer++;

            if(Timer < 500)
            {
                IMG_tutorial.SetActive(true);
            }
            if(Timer > 500)
            {
                IMG_tutorial.SetActive(false);
                Num_C.SetActive(true);
            }
            if(Timer > 900)
            {
                Num_C.SetActive(false);
                Num_B.SetActive(true);
            }
            if(Timer > 1200)
            {
                Num_B.SetActive(false);
                Num_A.SetActive(true);
            }
            if(Timer >+ 1500)
            {
                Num_A.SetActive(false);
                Num_GO.SetActive(true);
                //StartCoroutine(this.LoadingEnd());
                Time.timeScale = 1.0f;
                SceneManager.LoadScene("rune");
            }
        }
    }
    /*
    IEnumerator LoadingEnd()
    {
        //yield return new WaitForSeconds(1.0f);
        //Num_GO.SetActive(false);
    }*/

    
}
