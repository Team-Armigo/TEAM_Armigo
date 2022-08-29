using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARCore;
using Unity.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Declare Variables
    private string GROUND_TAG = "Ground";
    private string ENEMY_TAG = "Enemy";

    private bool isGrounded = false;

    public float gnew = 90f;

    public static int score;

/*    private int _score;
    public int score
    {
        get { return _score; }
        set { _score = value; }
    }*/

    public Text scoreOn;

    // Declare Components
    private Rigidbody mybody;


    private void Awake()
    {
        mybody = GetComponent<Rigidbody>();
    }

/*    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }*/

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            score++;
            scoreOn.text = score.ToString();
            Destroy(collision.gameObject); // 이 클래스가 부딪힌 오브젝트를 삭제, 클래스 삭제가 아니라
            Debug.Log("Score : " + score);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG)) // if collision happens with tag called GROUND_TAG
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject); // player destroyed
            Debug.Log("PLAYER COLLIDED");
        }
    }
}
