using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{

    AudioSource _audioSource;

    void Start()
    {
        
    }


    public static GameUI instance;
    // ����, ����������, �÷��� ������ MainMenu��

    // �����, ��ũ������Ʈ���� �븮��Ʈ��
    public void Previous()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void tab_continue()
    {
        Debug.Log("재생");
        GameObject.FindGameObjectWithTag("Music").GetComponent<OkayAudio>().PlayMusic();
        StartCoroutine(nextScene());
    }
    IEnumerator nextScene()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("1_Login");
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
