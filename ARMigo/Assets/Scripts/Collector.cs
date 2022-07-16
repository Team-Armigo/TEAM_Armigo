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
        //    Destroy(collision.gameObject); // 이 클래스가 부딪힌 오브젝트를 삭제, 클래스 삭제가 아니라
    }
}
