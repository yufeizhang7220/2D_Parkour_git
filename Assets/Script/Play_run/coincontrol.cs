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
    //������ʱ����ͬʱ������Ч
    private void OnTriggerEnter2D(Collider2D other)
    {
        //�������ʱ��������������������
        audiomanager.instance.Play("���");
        Destroy(gameObject);
    }
}
