using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public Text endPoint;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("FROM OTHER SCENE SCORE TEST : " + Timer.score);
        endPoint.text = Timer.score.ToString() + " POINTS";
    }
}
