using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : Player
{

    [SerializeField]
    private float timeRemaining = 30;

    public Text timerOn;

    public bool isTimerOn = false;

    //public GameOverScript GameOverScript;

    public void GameOver()
    {
        Debug.Log("YOUR TOTAL SCORE IS : " + score);
        SceneManager.LoadScene("GameOver");
    }

    // Start is called before the first frame update
    void Start()
    {
        isTimerOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimerOn)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;

                int time = (int)timeRemaining;
                Debug.Log("Time = " + time);
                timerOn.text = time.ToString();


            }

            else
            {
                timeRemaining = 0;
                isTimerOn = false;
                GameOver();
            }
        }

    }
}