using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgControl : MonoBehaviour
{
    //�����ٶ�
    public float speed = 0.9f;

    void Start()
    {
        
    }

    void Update()
    {
        //����������ͣ�ƶ�
        if (playercontrol.hp == 0)
        {
            return;
        }

        //�������Ʋ���ѭ��
        //��ȡ��������Ʒ��transform���
        foreach (Transform tran in transform)
        {
            //��ȡλ��
            Vector3 pos = tran.position;

            //���ƶ�
            pos.x -= speed * Time.deltaTime;
            tran.position = pos;

            //ѭ��
            if (pos.x < -7.2f)
            {
                pos.x+=7.2f * 2;
                tran.position = pos;
            }
        }
    }
}
