using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreElement : MonoBehaviour
{
    public TMP_Text number;
    public TMP_Text usernameText;
    public TMP_Text scoreText;


    public void NewScoreElement (string _username, int _score, int _number)
    {
        usernameText.text = _username;
        scoreText.text = _score.ToString();
        number.text = _number.ToString();
        // 방 안에 있는 유저들 수 만큼
        // PhotonNetwork.countOfPlayers
    }
}
