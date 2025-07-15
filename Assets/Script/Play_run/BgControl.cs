using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgControl : MonoBehaviour
{
    //控制速度
    public float speed = 0.9f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //任务死亡暂停移动
        if (playercontrol.hp == 0)
        {
            return;
        }
        //不断左移并且循环
        foreach (Transform tran in transform)
        {
            Vector3 pos = tran.position;
            pos.x -= speed * Time.deltaTime;
            tran.position = pos;
            if (pos.x < -7.2f)
            {
                pos.x+=7.2f * 2;
                tran.position = pos;

            }
        }
    }
}
