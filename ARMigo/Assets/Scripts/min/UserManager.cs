using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class UserManager : MonoBehaviourPunCallbacks
{
    public GameObject userPrefab;
    public TMP_Text playerNickname;
    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        //새로 플레이어가 들어왔으면 숫자 count
        count++;
        //숫자만큼 플레이어 수 for 사용해서 닉네임 띄우기
        //userList(newPlaye);
        
    }

    public override void OnPlayerLeftRoom(Photon.Realtime.Player newPlayer)
    {
        //플레이어가 나갔으면 -count
        count--;
        //userList(newPlaye);

    }

    void userList(Player player)
    {
        //playerNickname.text = PhotonNetwork.Nickname;
    }
}
