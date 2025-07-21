using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgControl : MonoBehaviour
{
    //控制速度
    public float speed = 0.9f;

    void Start()
    {
        
    }

    void Update()
    {
        //任务死亡暂停移动
        if (playercontrol.hp == 0)
        {
            return;
        }

        //不断左移并且循环
        //获取所有子物品的transform组件
        foreach (Transform tran in transform)
        {
            //获取位置
            Vector3 pos = tran.position;

            //左移动
            pos.x -= speed * Time.deltaTime;
            tran.position = pos;

            //循环
            if (pos.x < -7.2f)
            {
                pos.x+=7.2f * 2;
                tran.position = pos;
            }
        }
    }
}
