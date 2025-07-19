using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class coincontrol : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
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
