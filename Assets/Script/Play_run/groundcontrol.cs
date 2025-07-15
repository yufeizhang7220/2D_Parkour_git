using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundcontrol : MonoBehaviour
{
    public float speed = 2.0f;
    public GameObject[] groundprefabs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //任务死亡时停止移动
        if (playercontrol.hp == 0)
        {
            return;
        }
        //控制地面左移并且随机循环
        foreach (Transform tran in transform)
        {
            Vector3 pos = tran.position;
            pos.x -= speed * Time.deltaTime;
            if (pos.x < -7.2f)
            {
                Transform newtrans = Instantiate(groundprefabs[Random.Range(0, groundprefabs.Length)],transform).transform;
                Vector2 newpos = newtrans.position;
                newpos.x = pos.x + 7.2f * 2;
                newtrans.position = newpos;
                //pos.x += 7.2f * 2;
                Destroy(tran.gameObject);
            }
            tran.position = pos;
        }
    }
}
