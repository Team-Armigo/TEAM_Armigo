using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textBlink : MonoBehaviour
{
    Text _lbl;
    public float FadeIn = 1f;
    public float Stay = 1f;
    public float FadeOut = 1f;
    private float _time = 0;
    private Color _color;
    public float _direction=1;
    private float count = 0;

    void Start()
    {   
        _lbl = GetComponent<Text>();
        _color = _lbl.color;
        
    }
    void Update()
    {
        _time+=_direction*Time.deltaTime;
        _lbl.color = new Color(_color.r, _color.g, _color.b, 1-Mathf.Abs(Mathf.Sin(_time)));
    }
}
