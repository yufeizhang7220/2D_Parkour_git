using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundcontrol : MonoBehaviour
{
    //控制自身速度
    public float speed = 2.0f;

    //获取地表数组
    public GameObject[] groundprefabs;

    void Start()
    {
        speed = 2.0f;
    }

    void Update()
    {
        //任务死亡时停止移动
        if (playercontrol.hp == 0)
        {
            return;
        }
        //控制地面左移并且随机循环
        //获取子物品transform组件
        foreach (Transform tran in transform)
        {
            //获取位置
            Vector3 pos = tran.position;
            //获取应当移动距离
            pos.x -= speed * Time.deltaTime;

            //循环
            if (pos.x < -7.2f)
            {
                //随机实体化一个新地面
                Transform newtrans = Instantiate(groundprefabs[Random.Range(0, groundprefabs.Length)],transform).transform;
                //获取该地面的位置
                Vector2 newpos = newtrans.position;
                //移动至应该在的地方
                newpos.x = pos.x + 7.2f * 2;
                newtrans.position = newpos;
                //摧毁旧地面
                Destroy(tran.gameObject);
            }
            //移动
            tran.position = pos;
        }
    }
}
