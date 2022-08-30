using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroundScroller : MonoBehaviour
{
    public Image[] tiles;
    public Sprite[] groundImg;
    //public Image[] groundImg;
    public float speed = 100;
    Image temp;

    // Start is called before the first frame update
    void Start()
    {
        temp = tiles[0];
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < tiles.Length; i++)
        {
            //Debug.Log("X COR = " + tiles[0].transform.position.x + "X2 COR = " + tiles[1].transform.position.x);
            if(-95 >= tiles[i].transform.position.x)
            {
                for (int q = 0; q < tiles.Length; q++)
                {
                    if (temp.transform.position.x < tiles[q].transform.position.x)
                        temp = tiles[q];
                }

                tiles[i].transform.position = new Vector2(temp.transform.position.x + 180, temp.transform.position.y);
                tiles[i].sprite = groundImg[Random.Range(0, groundImg.Length)];
            }
        }
        for (int i = 0; i < tiles.Length; i++)
        {
            //RectTransform[] tiles = GetComponent<RectTransform[tiles.Length]>();
            //tiles[i].anchoredPosition = new Vector2(tiles[i].anchoredPosition.x - 1, tiles[i].anchoredPosition.y);
            tiles[i].transform.Translate(new Vector2(-1, 0) * Time.deltaTime * GameManager.instance.gameSpeed);
            //tiles[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(tiles[i].transform.position.x - 1, tiles[i].transform.position.y);
        }
    }
}
