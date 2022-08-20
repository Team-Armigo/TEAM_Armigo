using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun; 
using Photon.Realtime; 
using UnityEngine.SceneManagement;

public class roomlist : MonoBehaviourPunCallbacks 
{

    //public string friendsUserIds = "mineo";
    
    // Start is called before the first frame update
    void Start()
    {
        //PhotonNetwork.FindFriends(friendsUserIds);
        //Debug.Log(PhotonNetwork.CountOfPlayersOnMaster);
        //PhotonNetwork.CountOfPlayersOnMaster();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(PhotonNetwork.CountOfPlayersOnMaster);
    }
/*
    void OnUpdatedFriendList()
    {
        for(int i=0; i<PhotonNetwork.Friends.Count; i++)
        {
            FriendInfo friend = PhotonNetwork.Friends[i];
            Debug.LogFormat("{0}", friend);
        }
    }
*/
    public override void OnRoomListUpdate(List<RoomInfo> roomList) 
    { 
        // 룸 리스트 콜백은 로비에 접속했을때 자동으로 호출된다. 
        // 로비에서만 호출할 수 있음... 
        Debug.Log($"룸 리스트 업데이트 ::::::: 현재 방 갯수 : {roomList.Count}"); 
        Debug.Log(roomList);
    } 

    public void OnRanomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short _returnCode, string _message)
    {
        Debug.Log(_message);
    } 


    public override void OnJoinedRoom()
    {
        Debug.Log("04.방 입장 완료. 방 씬으로 옮김.-create");
        SceneManager.LoadScene("RoomMain");

        if(PhotonNetwork.IsMasterClient)
        {
            //PhotonNetwork.LoadLevel("Level_1");
            Debug.Log("IF");
        }
    }
}
