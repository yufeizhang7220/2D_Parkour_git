using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magnet_comtrol : MonoBehaviour
{
    public menu_inGame fuction_menu;

    public static bool is_attract = false;
    void Start()
    {
        is_attract = false;
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //��������ʱ��������������ʼ��������������
        audiomanager.instance.Play("���");
        is_attract = true;
        fuction_close();
        Destroy(gameObject);
        

    }

    public void fuction_close()
    {
        fuction_menu.close_attract_invoke();
    }
    
}
