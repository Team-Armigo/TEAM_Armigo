using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TumbleGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject poop;

    void Start()
    {
        StartCoroutine(CreatepoopRoutine());
    }

    void Update()
    {

    }

    private IEnumerator CreatepoopRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            Vector3 pos = new Vector3(UnityEngine.Random.Range(-400.0f, 400.0f), 1000.0f, 1);
            pos.z = 1.0f;

            GameObject newEnemy = Instantiate(poop, pos, Quaternion.identity);
            newEnemy.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        }
    }
}
