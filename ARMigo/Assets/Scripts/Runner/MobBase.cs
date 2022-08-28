using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobBase : MonoBehaviour
{
    public float mobSpeed = 100;

    public Vector2 StartPosition;

    private void OnEnable()
    {
        StartPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * GameManager.instance.gameSpeed);

        if (transform.position.x < -85)
        {
            gameObject.SetActive(false);
        }
    }
}
