using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heart_control : MonoBehaviour
{
    public int hp_max = 3;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //增加hp
        if (collision.CompareTag("Player"))
        {
            //给与一个最大hp值
            if (playercontrol.hp < hp_max)
            {
                audiomanager.instance.Play("金币");
                playercontrol.hp++;
                Destroy(gameObject);
            }
        }
    }
}
