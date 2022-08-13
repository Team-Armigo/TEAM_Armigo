using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class CreateRooms : MonoBehaviourPunCallbacks
{

    
    public TMP_InputField roomName;

    public TMP_Dropdown num;


    [SerializeField]
    public TMP_InputField password;

    public Button createRoom;
    //public Button backRoom;

    private RoomInfo roomInfo;

 

    public void OnClick_CreateRoom()
    {
        if (!PhotonNetwork.IsConnected) return;

        RoomOptions options = new RoomOptions();
        // options.RoomName = _roomName.text;
        //options.MaxPlayers = (byte)int.Parse(maxNum.text);

        PhotonNetwork.CreateRoom(roomName.text, options, TypedLobby.Default);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Created Room Successfully");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to Create Room");
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
