using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.SceneManagement;


public class RoomData : MonoBehaviourPunCallbacks
{

    private static TMP_Text RoomInfoText;
    private static RoomInfo _roomInfo;
    

    public TMP_InputField userIdText;

    public RoomInfo RoomInfo
    {
        get
        {
            Debug.Log("get함수가 실행되었다.");
            return _roomInfo;
        }

        set
        {
            _roomInfo = value;
            RoomInfoText.text = $"{_roomInfo.Name} ({_roomInfo.PlayerCount}/{_roomInfo.MaxPlayers})";
            GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => OnJoinRoom(_roomInfo.Name));
            Debug.Log("set함수가 실행되었다.");
        }
    }

    void Awake()
    {
        RoomInfoText = GetComponentInChildren<TMP_Text>(); 
        userIdText = GameObject.Find("InputField (TMP) - Nickname").GetComponent<TMP_InputField>();   
    }

    public void OnJoinRoom(string roomName)
    {
	// 룸 입장 함수 - roomName을 key값으로 검색해 입장합니다.
    PhotonNetwork.JoinRoom(roomName);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("04.방 입장 완료. 방 씬으로 옮김.-Room프리팹");
        SceneManager.LoadScene("RoomMain");

        if(PhotonNetwork.IsMasterClient)
        {
            //PhotonNetwork.LoadLevel("Level_1");
            Debug.Log("IF");
        }
    }

    public void UpdateInfo()
    {
        //RoomInfoText.text = string.Format("{0} [{1}/{2}]",_roomInfo.Name )
    }

}
