using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.SceneManagement;

//RoomData.cs
public class study : MonoBehaviour
{

    private static TMP_Text RoomInfoText;
    private static RoomInfo _roomInfo;

    //RoomInfo 에 대한 정보가 부족하지만 아마 방 정보를 다루는 역할인듯하다. 
    

    public TMP_InputField userIdText;
    

    // 프로퍼티에 관한 내용 https://developer-talk.tistory.com/39
    public RoomInfo RoomInfo
    {
        get
        {
            return _roomInfo;
        }

        set
        {
            _roomInfo = value;
            // EX: room_03 (1/2)
            RoomInfoText.text = $"{_roomInfo.Name} ({_roomInfo.PlayerCount}/{_roomInfo.MaxPlayers})";
            // 버튼의 클릭 이벤트에 함수를 연결ㄴ
            // GetComponent: 동일한 게임오브젝트가 갖고 있는 특정 다른 컴포넌트에 접근해야 할 경우 사용하는 방법
            // 출처: https://codingmania.tistory.com/147 [개발자의 개발 블로그:티스토리]
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

/*
    public void OnRoomListUpdate(List<RoomInfo> roomList)
    {
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
    //이코드 작동 
    public override void OnCreatedRoom()
    {
        Debug.Log("03.방 생성 완료-Room");
    }
    //이코드 작동 
    public override void OnJoinedRoom()
    {
        Debug.Log("04.방 입장 완료. 방 씬으로 옮김.- room");
        SceneManager.LoadScene("RoomMain");

        if(PhotonNetwork.IsMasterClient)
        {
            //PhotonNetwork.LoadLevel("Level_1");
            Debug.Log("IF");
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    */
}
