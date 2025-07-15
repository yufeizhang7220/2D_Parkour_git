using System.Collections;
using System.Collections.Generic;
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
        audiomanager.instance.Play("金币");
        Destroy(gameObject);
    }
}
