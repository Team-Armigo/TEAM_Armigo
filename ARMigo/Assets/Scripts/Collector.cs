using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log(">>>>> COLLISION HAPPENED >>>>>>>");
        Destroy(collision.gameObject);

        //if (collision.CompareTag("Enemy") || collision.CompareTag("Player"))
        //    Destroy(collision.gameObject); // �� Ŭ������ �ε��� ������Ʈ�� ����, Ŭ���� ������ �ƴ϶�
    }
}
