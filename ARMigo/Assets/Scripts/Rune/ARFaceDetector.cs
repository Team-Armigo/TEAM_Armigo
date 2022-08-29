using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARCore;
using Unity.Collections;
using UnityEngine.UI;

public class ARFaceDetector : MonoBehaviour
{
    NativeArray<ARCoreFaceRegionData> regionData;

    public ARFaceManager afm;

    [SerializeField]
    private float moveForce = 200f;

    private float movementX;

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

    // Start is called before the first frame update
    void Start()
    {
        // AR Face Manager�� ���� �ν��� �� ������ �Լ��� �����Ѵ�.
        afm.facesChanged += OnDetectFaceAll;

        // AR Foundation�� XRFaceSubsystem Ŭ���� ������ AR Core�� ARCoreFaceSubsytem Ŭ���� ������ ĳ�����Ѵ�.
        subSys = (ARCoreFaceSubsystem)afm.subsystem;
    }

    // Update is called once per frame
    void Update()
    {
        
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
            xCor = vertPosition.x;
            yCor = vertPosition.y;

            if (xCor <= -0.04)
            {
                movementX = 1f;
                gameObject.transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
            }

            else if (xCor >= 0.02)
            {
                movementX = -1f;
                gameObject.transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;

            }

        }

        // ���� �ν����� ������ ����...
        else if (args.removed.Count > 0)
        {

        }

    }
}
