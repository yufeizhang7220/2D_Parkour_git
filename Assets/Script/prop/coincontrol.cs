using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class coincontrol : MonoBehaviour
{
    //��ȡ��ҵ�transform,collider���
    public Transform player_tran;
    public CapsuleCollider2D player_collider;

    //����������������Լ������ٶ�
    public float attract_distance=5f;
    public float attract_speed = 5f;
    void Start()
    {
        
    }

    void Update()
    {
        //��������
        if (magnet_comtrol.is_attract == true)
        {
            if (Vector2.Distance(transform.position, player_tran.position) < attract_distance)
            {
                transform.Translate(((Vector2)player_tran.position+player_collider.offset- (Vector2)transform.position).normalized * attract_speed * Time.deltaTime);
            }
        }
    }

    //������ʱ����ͬʱ������Ч
    private void OnTriggerEnter2D(Collider2D other)
    {
        //�������ʱ��������������������
        audiomanager.instance.Play("���");
        Destroy(gameObject);
    }
}
