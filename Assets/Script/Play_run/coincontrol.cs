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

    //������ʱ����ͬʱ������Ч
    private void OnTriggerEnter2D(Collider2D other)
    {
        //�������ʱ��������������������
        audiomanager.instance.Play("���");
        Destroy(gameObject);
    }
}
