using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public ARFaceManager faceManager;
    public Material[] faceMats;
    //public Text indexText;
    //public Text xText;

    //int vertNum = 0;
    //int vertCount = 468;

    private void Start()
    {
        // ������ �ε��� ���� 0���� �ʱ�ȭ�Ѵ�.
        // indexText.text = vertNum.ToString();
    }

    // ��ư�� ������ �� ������ �Լ�
    public void ToggleMaskImage()
    {
        // faceManager ������Ʈ���� ���� ������ Face ������Ʈ�� ��� ��ȸ�Ѵ�.
        foreach (ARFace face in faceManager.trackables)
        {
            // ���� Face ������Ʈ�� ���� �ν��ϰ� �ִ� ���¶��...
            if (face.trackingState == TrackingState.Tracking)
            {
                // Face ������Ʈ�� Ȱ��ȭ ���¸� �ݴ�� �����Ѵ�.
                face.gameObject.SetActive(!face.gameObject.activeSelf);
            }
        }
    }

    public void SwitchFaceMaterial(int num)
    {
        // faceManager ������Ʈ���� ���� ������ Face ������Ʈ�� ��� ��ȸ�Ѵ�.
        foreach (ARFace face in faceManager.trackables)
        {
            // ���� Face ������Ʈ�� ���� �ν��ϰ� �ִ� ���¶��...
            if (face.trackingState == TrackingState.Tracking)
            {
                // Face ������Ʈ�� MeshRenderer ������Ʈ�� �����Ѵ�.
                MeshRenderer mr = face.GetComponent<MeshRenderer>();

                // ��ư�� ������ ��ȣ(�̹���: 0��, ����: 1��)�� �ش��ϴ� ���͸���� �����Ѵ�.
                mr.material = faceMats[0];
            }
        }
    }

    /*public void IndexIncrease()
    {
        // ventNum�� ���� 1 ������Ű��, �ִ� �ε����� ���� �ʵ��� �Ѵ�.
        int number = Mathf.Min(++vertNum, vertCount - 1);
        indexText.text = number.ToString();
    }

    public void IndexDecrease()
    {
        // ventNum�� ���� 1 ���ҽ�Ű��, 0�� ���� �ʵ��� �Ѵ�.
        int number = Mathf.Max(--vertNum, 0);
        indexText.text = number.ToString();
    }*/
}
