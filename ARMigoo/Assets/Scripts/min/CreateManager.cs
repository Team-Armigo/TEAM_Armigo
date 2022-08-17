using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.SceneManagement;

public class CreateManager : MonoBehaviourPunCallbacks
{
    public TMP_InputField userIdText;
    public TMP_InputField roomNameText;
    public TMP_Dropdown maxNum;
    public TMP_InputField passWord;


    //룸 목록 저장하기 위한 딕셔너리 자료형 
    private Dictionary<string, GameObject> roomDict = new Dictionary<string, GameObject>();
    // 룸을 표시할 프리팹 
    public GameObject roomPrefab;
    // Room 프리팹이 차일드화 시킬 부모 객체 
    public Transform scrollContent;
    
/*
    private void Awake()
    {
        // 방장 혼자 씬 로딩하면 , 나머지 사람들 자동으로 싱크 
        PhotonNetwork.AutomaticallySyncScene = true;
    }
*/
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("00.포톤 매니저 시작 ");
        // 서버 접속 
        //PhotonNetwork.ConnectUsingSettings();
    }
/*
    public override void OnConnectedToMaster()
    {
        Debug.Log("01. 포톤 서버에 접속 ");
        // 로비에 접속
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("02. 로비에 접속 ");
    }

    */
    //이코드 작동 
    public override void OnCreatedRoom()
    {
        Debug.Log("03.방 생성 완료-create");
    }
    //이코드 작동 
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
    public void OnCreateRoomFailed()
    {
        Debug.Log("05.방 입장 실패");
    }


    // 룸 리스트 초기화 - 현재 생성된 룸들의 정보가 담긴 리스트가 매개변수로 온다.
    // 로비 내에 룸이 생성되거나 사라질때 자동 호출되는 콜백
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        Debug.Log($"룸 리스트 업데이트 ::::::: 현재 방 갯수 : {roomList.Count}"); 
        GameObject tempRoom = null;
        foreach(var room in roomList)
        {
            // 룸이 삭제된 경우
            if (room.RemovedFromList == true)
            {
                roomDict.TryGetValue(room.Name, out tempRoom);
                Destroy(tempRoom);
                roomDict.Remove(room.Name);
            }
            // 룸 정보가 갱신 (변경 ) 된 경우 
            else
            {
                // 룸이 처음 생성된 경우
                if (roomDict.ContainsKey(room.Name) == false)
                {
                    GameObject _room = Instantiate(roomPrefab, scrollContent);
                    _room.GetComponent<RoomData>().RoomInfo = room;
                    roomDict.Add(room.Name, _room);
                }
                // 룸 정보를 갱신하는 경우
                else
                {
                    roomDict.TryGetValue(room.Name, out tempRoom);
                    tempRoom.GetComponent<RoomData>().RoomInfo = room;
                }
            }
        }
    }
    
    public void RoomCreate()
    {
        byte maxPlayers = byte.Parse(maxNum.options[maxNum.value].text); // 드롭다운에서 값 얻어오기.
        
        RoomOptions ro = new RoomOptions();
        //ro.RoomName = roomNameText;
        ro.MaxPlayers = maxPlayers;
        ro.IsOpen = true;
        ro.IsVisible = true;

        // 인풋필드가 비어있으면
        if(string.IsNullOrEmpty(roomNameText.text))
        {
            //랜덤 룸 이름 부여
            roomNameText.text = $"ROOM_{Random.Range(1, 100):000}";
        }
        //생성과 동시에 입장.성공. 
        PhotonNetwork.CreateRoom(roomNameText.text, ro);
        Debug.Log("코드가 작동은 되었다.-Room");
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}