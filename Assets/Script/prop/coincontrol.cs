using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class coincontrol : MonoBehaviour
{
    //获取玩家的transform,collider组件
    public Transform player_tran;
    public CapsuleCollider2D player_collider;

    //声明金币吸引距离以及吸引速度
    public float attract_distance=5f;
    public float attract_speed = 5f;
    void Start()
    {
        
    }

    void Update()
    {
        //控制吸引
        if (magnet_comtrol.is_attract == true)
        {
            if (Vector2.Distance(transform.position, player_tran.position) < attract_distance)
            {
                transform.Translate(((Vector2)player_tran.position+player_collider.offset- (Vector2)transform.position).normalized * attract_speed * Time.deltaTime);
            }
        }
    }

    //被触碰时销毁同时播放音效
    private void OnTriggerEnter2D(Collider2D other)
    {
        //碰到金币时，发出声音，并且销毁
        audiomanager.instance.Play("金币");
        Destroy(gameObject);
    }
}
