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
        // AR Face Manager�� ���� �ν��� �� ������ �Լ��� �����Ѵ�.
        // afm.facesChanged += OnDetectThreePoints;
        afm.facesChanged += OnDetectFaceAll;

        // AR Foundation�� XRFaceSubsystem Ŭ���� ������ AR Core�� ARCoreFaceSubsytem
        // Ŭ���� ������ ĳ�����Ѵ�.
        subSys = (ARCoreFaceSubsystem)afm.subsystem;
    }

    // Update is called once per frame
    void Update()
    {
        mybody.AddForce(new Vector3(0, -1.0f, 0) * mybody.mass * gnew);
        Debug.Log(isGrounded);
    }

    // �� �޽� �����͸� �̿��� ���
    void OnDetectFaceAll(ARFacesChangedEventArgs args)
    {
        // ���� �ν����� ����...
        if (args.updated.Count > 0)
        {
            // �ؽ�Ʈ UI�� ���� ���ڿ� �����͸� ������ �����ͷ� ��ȯ�Ѵ�.
            // int num = int.Parse(vertexIndex.text);

            // �� ���� �迭���� ������ �ε����� �ش��ϴ� ��ǥ�� �����´�.
            Vector3 vertPosition = args.updated[0].vertices[4];
            //Vector3 vertPosition = args.updated[0].vertices[num];

            // ���� ��ǥ�� ���� ��ǥ�� ��ȯ�Ѵ�.
            vertPosition = args.updated[0].transform.TransformPoint(vertPosition);

            // x, y ��ǥ�� �����ͼ� �ؽ�Ʈ�� ����
            xCor = vertPosition.x;
            yCor = vertPosition.y;


            // �� ���� ������ �������� ��
            // �� ���� ������ ���ߴ� �ڵ�

            // �������� �ʹ� ���� ����

            // ���� ���
            // �ǰ� ����
            // ��Ʈ ����
    

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

        // ���� �ν����� ������ ����...
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
