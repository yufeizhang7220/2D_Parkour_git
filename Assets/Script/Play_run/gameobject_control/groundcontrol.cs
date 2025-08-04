using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundcontrol : MonoBehaviour
{
    //���������ٶ�
    public float speed = 2.0f;

    //��ȡ�ر�����
    public GameObject[] groundprefabs;

    void Start()
    {
        speed = 2.0f;
    }

    void Update()
    {
        //��������ʱֹͣ�ƶ�
        if (playercontrol.hp == 0)
        {
            return;
        }
        //���Ƶ������Ʋ������ѭ��
        //��ȡ����Ʒtransform���
        foreach (Transform tran in transform)
        {
            //��ȡλ��
            Vector3 pos = tran.position;
            //��ȡӦ���ƶ�����
            pos.x -= speed * Time.deltaTime;

            //ѭ��
            if (pos.x < -7.2f)
            {
                //���ʵ�廯һ���µ���
                Transform newtrans = Instantiate(groundprefabs[Random.Range(0, groundprefabs.Length)],transform).transform;
                //��ȡ�õ����λ��
                Vector2 newpos = newtrans.position;
                //�ƶ���Ӧ���ڵĵط�
                newpos.x = pos.x + 7.2f * 2;
                newtrans.position = newpos;
                //�ݻپɵ���
                Destroy(tran.gameObject);
            }
            //�ƶ�
            tran.position = pos;
        }
    }
}
