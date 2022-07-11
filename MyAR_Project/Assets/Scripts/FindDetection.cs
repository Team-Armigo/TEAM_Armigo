using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARCore;
using Unity.Collections;
using UnityEngine.UI;

public class FindDetection : MonoBehaviour
{
    NativeArray<ARCoreFaceRegionData> regionData;

    public ARFaceManager afm;
    public GameObject smallCube;
    //public Text vertexIndex;
    public Text xCor;
    public Text yCor;

    List<GameObject> faceCubes = new List<GameObject>();
    ARCoreFaceSubsystem subSys;

    // Start is called before the first frame update
    void Start()
    {
        // ��ġ�� ǥ���ϱ� ���� ���� ť�� 3���� �����Ѵ�.
        for(int i = 0; i < 3; i++)
        {
            GameObject go = Instantiate(smallCube);
            faceCubes.Add(go);
            go.SetActive(false);
        }

        // AR Face Manager�� ���� �ν��� �� ������ �Լ��� �����Ѵ�.
        // afm.facesChanged += OnDetectThreePoints;
        afm.facesChanged += OnDetectFaceAll;

        // AR Foundation�� XRFaceSubsystem Ŭ���� ������ AR Core�� ARCoreFaceSubsytem
        // Ŭ���� ������ ĳ�����Ѵ�.
        subSys = (ARCoreFaceSubsystem)afm.subsystem;
    }

    /*// facesChanged ��������Ʈ(Action)�� ������ �Լ�
    void OnDetectThreePoints (ARFacesChangedEventArgs args)
    {
        // �� �ν� ������ ���ŵ� ���� �ִٸ�...
        if (args.updated.Count > 0)
        {
            // �νĵ� �󱼿��� Ư�� ��ġ�� �����´�.
            subSys.GetRegionPoses(args.updated[0].trackableId, Allocator.Persistent, ref regionData);

            // �νĵ� ���� Ư�� ��Ƽ (0: �� ��, 1: �̸� ����, 2: �̸� ����)�� ������Ʈ�� ��ġ�Ѵ�.
            for (int i = 0; i < regionData.Length; i++)
            {
                faceCubes[i].transform.position = regionData[i].pose.position;
                faceCubes[i].transform.rotation = regionData[i].pose.rotation;
                faceCubes[i].SetActive(true);
            }
        }

        else if (args.removed.Count > 0)
        {
            // ������Ʈ�� ��Ȱ��ȭ�Ѵ�.
            for (int i = 0; i < regionData.Length; i++)
            {
                faceCubes[i].SetActive(false);
            }
        }
    }*/

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
            xCor.text = vertPosition.x.ToString();
            yCor.text = vertPosition.y.ToString();

            // �غ�� ť�� �ϳ��� Ȱ��ȭ�ϰ� ���� ��ġ�� ������ ���´�. 
            faceCubes[0].SetActive(true);
            faceCubes[0].transform.position = vertPosition;
        }
        
        // ���� �ν����� ������ ����...
        else if (args.removed.Count > 0)
        {
            faceCubes[0].SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
