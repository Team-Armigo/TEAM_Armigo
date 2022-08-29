using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARCore;
using Unity.Collections;
using UnityEngine.UI;

public class ARFaceDetector1 : MonoBehaviour
{
    NativeArray<ARCoreFaceRegionData> regionData;

    public ARFaceManager afm;

    [SerializeField]
    private float moveForce = 200f;

    private float movementX;

    bool isJump = false;
    bool isTop = false;
    public float jumpHeight = 0;
    public float jumpSpeed = 0;
    Vector2 startPosition;
    Animator animator;

    public GameObject gameObject;

    private float _xCor;
    public float xCor
    {
        get { return _xCor; }
        set { _xCor = value; }
    }

    private float _yCor;
    public float yCor
    {
        get { return _yCor; }
        set { _yCor = value; }
    }

    ARCoreFaceSubsystem subSys;

    public Text yCorText;
    private float movementY;


    // Start is called before the first frame update
    void Start()
    {
        startPosition = gameObject.transform.position;
        animator = gameObject.GetComponent<Animator>();

        // AR Face Manager�� ���� �ν��� �� ������ �Լ��� �����Ѵ�.
        afm.facesChanged += OnDetectFaceAll;

        // AR Foundation�� XRFaceSubsystem Ŭ���� ������ AR Core�� ARCoreFaceSubsytem Ŭ���� ������ ĳ�����Ѵ�.
        subSys = (ARCoreFaceSubsystem)afm.subsystem;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Animator>().SetBool("Run", true);

    }

    // �� �޽� �����͸� �̿��� ���
    void OnDetectFaceAll(ARFacesChangedEventArgs args)
    {
        // ���� �ν����� ����...
        if (args.updated.Count > 0)
        {
            // �� ���� �迭���� ������ �ε����� �ش��ϴ� ��ǥ�� �����´�.
            Vector3 vertPosition = args.updated[0].vertices[4];
            //Vector3 vertPosition = args.updated[0].vertices[num];

            // ���� ��ǥ�� ���� ��ǥ�� ��ȯ�Ѵ�.
            vertPosition = args.updated[0].transform.TransformPoint(vertPosition);

            // x, y ��ǥ�� �����ͼ� ����
            //xCor = vertPosition.x;
            yCorText.text = vertPosition.y.ToString();
            yCor = vertPosition.y;

            if (yCor >= 0.01)
            {
                isJump = true;
            }

            else if (gameObject.transform.position.y >= startPosition.y)
            {
                isJump = false;
                isTop = false;
                gameObject.transform.position = startPosition;
            }

            if (isJump)
            {
                movementY = 10f;
                gameObject.transform.position += new Vector3(0f, movementY, 0f) * Time.deltaTime * moveForce;

/*                if (gameObject.transform.position.y <= jumpHeight - 0.1f && !isTop)
                {
                    gameObject.transform.position = Vector2.Lerp(transform.position,
                    new Vector2(transform.position.x, jumpHeight), jumpSpeed * Time.deltaTime);
                }

                else
                {
                    isTop = true;
                }

                if (transform.position.y > startPosition.y && isTop)
                {
                    transform.position = Vector2.MoveTowards(transform.position, startPosition, jumpSpeed * Time.deltaTime);
                }*/
            }
        }

        // ���� �ν����� ������ ����...
        else if (args.removed.Count > 0)
        {

        }

    }
}
