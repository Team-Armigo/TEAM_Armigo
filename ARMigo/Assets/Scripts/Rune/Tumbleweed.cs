using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tumbleweed : MonoBehaviour
{
    // Adding Variables
    [SerializeField]
    private float moveForce = 10f;

    private float GRAVITY = 9.8f;

    private float Velocity = 0f;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            //Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            Destroy(gameObject);
        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 current = this.transform.position;

        Velocity += GRAVITY * Random.Range(1.0f, 3.0f) * Time.deltaTime;

        current.y -= Velocity * Time.deltaTime * moveForce;
        this.transform.position = current;
    }
}
