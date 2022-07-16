using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TumbleGenerator : MonoBehaviour
{
    /*const float CREATE_INTERVAL = 0.18f;
    float mCreatTime = 0;
    float mTotalTIme = 0;

    float mNextCreateInterval = CREATE_INTERVAL;

    int mPhase = 1;

    public GameObject mDong;

    private void Update()
    {
        mTotalTIme += Time.deltaTime;
        mCreatTime += Time.deltaTime;
        if (mCreatTime > mNextCreateInterval)
        {
            mCreatTime = 0;
            mNextCreateInterval = CREATE_INTERVAL - (0.005f * mTotalTIme);
            //Debug.Log("mNextCreateInterval : " + mNextCreateInterval);
            if (mNextCreateInterval < 0.005f)
            {
                mNextCreateInterval = 0.005f;
            }

            for (int i = 0; i < mPhase; i++)
            {
                createDdong(8f + i * 0.2f);
            }

        }

        if (mTotalTIme >= 10f)
        {
            mTotalTIme = 0;
            mPhase++;
        }
    }

    private void createDdong(float y)
    {
        float x = Random.Range(-4f, 4f);
        createObject(mDong, new Vector3(x, y, 0), Quaternion.identity);
    }

    private GameObject createObject(GameObject original, Vector3 position, Quaternion rotation)
    {
        return (GameObject)Instantiate(original, position, rotation);
    }*/


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
            Vector3 pos = new Vector3(UnityEngine.Random.Range(-500.0f, 500.0f), 1000.0f, 1);
            pos.z = 1.0f;

            GameObject newEnemy = Instantiate(poop, pos, Quaternion.identity);
            newEnemy.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        }
    }
}
