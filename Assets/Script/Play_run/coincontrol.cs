using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class coincontrol : MonoBehaviour
{
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    //被触碰时销毁同时播放音效
    private void OnTriggerEnter2D(Collider2D other)
    {
        //碰到金币时，发出声音，并且销毁
        audiomanager.instance.Play("金币");
        Destroy(gameObject);
    }
}
