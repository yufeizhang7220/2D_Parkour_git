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
        //����hp
        if (collision.CompareTag("Player"))
        {
            //����һ�����hpֵ
            if (playercontrol.hp < hp_max)
            {
                audiomanager.instance.Play("���");
                playercontrol.hp++;
                Destroy(gameObject);
            }
        }
    }
}
