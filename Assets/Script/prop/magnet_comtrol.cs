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
        //��������ʱ��������������ʼ��������������
        audiomanager.instance.Play("���");
        is_attract = true;
        Invoke("close_attract", 5f);
        Destroy(gameObject);

    }

    //ȡ����������
    public void close_attract()
    {
        is_attract = false;
    }
}
