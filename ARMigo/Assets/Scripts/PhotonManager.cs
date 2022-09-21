using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    //파베에서 아이디 가져오기
    private string userId = "mineo";

    private void Awake()
    {
        //방장이 혼자 씬을 로딩하면, 나머지 사람들은 자동으로 싱크가 됨
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        // 게임 버전 지정 
        //PhotonNetwork.GameVersion = "0.1";
        //유저 아이디 설정
        PhotonNetwork.NickName = userId;
        //마스터 서버에 접속을 위한 함수
        Connect();
    }


    public void Connect()
    {
        // we check if we are connected or not, we join if we are , else we initiate the connection to the server.
        if (PhotonNetwork.IsConnected)
        {
            //확인
            Debug.Log("02.이미 연결되어있음.");
        }            
        else
        {
            // 게임 버전 지정 
            PhotonNetwork.GameVersion = "0.1";
            // #Critical, we must first and foremost connect to Photon Online Server.
            //PhotonNetwork.GameVersion = gameVersion;                
            PhotonNetwork.ConnectUsingSettings();
            //확인
            Debug.Log("01.포톤 매니저 시작 ");
        }
    }

    public override void OnConnectedToMaster()
    {
        //확인
        Debug.Log("02.포톤 서버에 접속 성공");
        // 로비에 접속
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("03.로비에 접속 성공");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("00.연결이 끊켰음");
        //다시 접속 시도
        Connect();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
