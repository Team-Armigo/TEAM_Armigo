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
            return _roomInfo;
        }

        set
        {
            _roomInfo = value;
            RoomInfoText.text = $"{_roomInfo.Name} ({_roomInfo.PlayerCount}/{_roomInfo.MaxPlayers})";
            GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => OnEnterRoom(_roomInfo.Name));
        }
    }

    void Awake()
    {
        RoomInfoText = GetComponentInChildren<TMP_Text>();
        userIdText = GameObject.Find("InputField (TMP) - Nickname").GetComponent<TMP_InputField>();
        
    }

    void OnEnterRoom(string roomName)
    {
        RoomOptions ro = new RoomOptions();
        ro.IsOpen = true;
        ro.IsVisible = true;
        ro.MaxPlayers = 10;

        PhotonNetwork.NickName = userIdText.text;
        PhotonNetwork.JoinOrCreateRoom(roomName, ro, TypedLobby.Default);
    }


}
