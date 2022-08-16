using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{

    public static GameUI instance;
    // 세팅, 마이페이지, 플레이 게임은 MainMenu로

    // 룸메인, 룸크리에이트에서 룸리스트로
    public void Previous()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Login()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Signup()
    {

    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }


    public void MyPage()
    {
        SceneManager.LoadScene("MyPage");
    }

    public void RoomList()
    {
        SceneManager.LoadScene("RoomList");
    }

    public void RoomCreate()
    {
        SceneManager.LoadScene("RoomCreate");
    }

    public void RoomMain()
    {
        SceneManager.LoadScene("RoomMain");
    }

    public void Restart()
    {
        SceneManager.LoadScene("rune");
    }

    public void ChooseGame()
    {
        SceneManager.LoadScene("ChooseGame");
    }

    public void GameRune()
    {
        SceneManager.LoadScene("rune");
    }
}
