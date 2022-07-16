using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARCore;
using Unity.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private bool isGrounded = false;

    [SerializeField]
    private float moveForce = 200f;

    [SerializeField]
    private float jumpForce = 11f;

    private float movementX;


    private string GROUND_TAG = "Ground";
    private string ENEMY_TAG = "Enemy";
    private Rigidbody mybody;
    public float gnew = 90f;

    NativeArray<ARCoreFaceRegionData> regionData;

    public ARFaceManager afm;
    private float xCor;
    private float yCor;
    //public string command;

    List<GameObject> faceCubes = new List<GameObject>();
    ARCoreFaceSubsystem subSys;

    private void Awake()
    {
        mybody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // AR Face Manager가 얼굴을 인식할 때 실행할 함수를 연결한다.
        // afm.facesChanged += OnDetectThreePoints;
        afm.facesChanged += OnDetectFaceAll;

        // AR Foundation의 XRFaceSubsystem 클래스 변수를 AR Core의 ARCoreFaceSubsytem
        // 클래스 변수로 캐스팅한다.
        subSys = (ARCoreFaceSubsystem)afm.subsystem;
    }

    // Update is called once per frame
    void Update()
    {
        mybody.AddForce(new Vector3(0, -1.0f, 0) * mybody.mass * gnew);
        Debug.Log(isGrounded);
    }

    // 얼굴 메시 데이터를 이용한 방식
    void OnDetectFaceAll(ARFacesChangedEventArgs args)
    {
        // 얼굴을 인식했을 때는...
        if (args.updated.Count > 0)
        {
            // 텍스트 UI에 적힌 문자열 데이터를 정수형 데이터로 변환한다.
            // int num = int.Parse(vertexIndex.text);

            // 얼굴 정점 배열에서 지정한 인덱스에 해당하는 좌표를 가져온다.
            Vector3 vertPosition = args.updated[0].vertices[4];
            //Vector3 vertPosition = args.updated[0].vertices[num];

            // 정점 좌표를 월드 좌표로 변환한다.
            vertPosition = args.updated[0].transform.TransformPoint(vertPosition);

            // x, y 좌표를 가져와서 텍스트로 저장
            xCor = vertPosition.x;
            yCor = vertPosition.y;


            // 얼굴 정면 볼때도 왼쪽으로 감
            // 얼굴 정면 볼때는 멈추는 코드

            // 움직임이 너무 딱딱 끊김

            // 점수 계산
            // 피격 판정
            // 하트 판정
    

            if (xCor >= -0.04)
            {
                movementX = -1f;
                transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
            }

            else if (xCor <= 0.1)
            {
                movementX = 1f;
                transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;

            }

            if (yCor >= 0.02 && isGrounded)
            {
                isGrounded = false;
                mybody.AddForce(new Vector2(0f, jumpForce), ForceMode.Impulse);
            }

        }

        // 얼굴을 인식하지 못했을 때는...
        else if (args.removed.Count > 0)
        {

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG)) // if collision happens with tag called GROUND_TAG
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject); // player destroyed
        }
    }
}
