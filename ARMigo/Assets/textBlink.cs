using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textBlink : MonoBehaviour
{
    Text _lbl;
    private float _time = 0f;
    private Color _color;

    void Start()
    {   
        _lbl = GetComponent<Text>();
        _color = _lbl.color;
        
    }
    void Update()
    {
        _time+=Time.deltaTime;
        _lbl.color = new Color(_color.r, _color.g, _color.b, 1-0.7f*Mathf.Abs(Mathf.Sin(2*_time)));
    }
}
