using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class CreateRooms : MonoBehaviourPunCallbacks
{

    [SerializeField]
    private Text _roomName;

    [SerializeField]
    private Text _maxNum;

    [SerializeField]
    private Text _password;

    public void OnClick_CreateRoom()
    {
        if (!PhotonNetwork.IsConnected) return;

        RoomOptions options = new RoomOptions();
        // options.RoomName = _roomName.text;
        options.MaxPlayers = (byte)int.Parse(_maxNum.text);

        PhotonNetwork.CreateRoom(_roomName.text, options, TypedLobby.Default);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Created Room Successfully");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to Create Room");
    }
}
