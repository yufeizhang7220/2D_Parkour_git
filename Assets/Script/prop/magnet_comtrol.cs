using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magnet_comtrol : MonoBehaviour
{
    public static bool is_attract = false;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //碰到磁铁时，发出声音，开始吸引，并且销毁
        audiomanager.instance.Play("金币");
        is_attract = true;
        Invoke("close_attract", 5f);
        Destroy(gameObject);

    }

    //取消吸引函数
    public void close_attract()
    {
        is_attract = false;
    }
}
