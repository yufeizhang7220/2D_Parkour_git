using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playercontrol : MonoBehaviour
{
    //获取自身组件
    private Rigidbody2D rbody;
    private Animator ani;

    //判断是否触地
    private bool isGround;

    //静态申明血量，金币数量
    public static int hp=1;
    public static int coin_num = 0;

    //获取over_menu物品，以及coin_num的文本组件
    public GameObject over_menu;
    public TMP_Text coin_text;
    
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();

        //初始化hp，coin_num
        hp = 1;
        coin_num = 0;
        
        
    }

    void Update()
    {
        
        //空格判断跳跃
       if (Input.GetKeyDown(KeyCode.Space))
       {
                jump();
       }
       //死亡界面跳转
        if (hp == 0)
        {
            if (over_menu != null)
            {
                over_menu.SetActive(true);
            }

        }        
    }

    //跳跃功能
    public void jump()
    {
        if (isGround == true)
        {
            rbody.AddForce(Vector2.up * 400);
            audiomanager.instance.Play("跳");
        }
            
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //判断是否触地
        if (collision.collider.tag == "ground")
        {
            isGround = true;
        }
        ani.SetBool("isjump", false);

        //判断是否出界，导致扣血，死亡
        if (collision.collider.tag == "die"&&hp>0)
        {
            hp = 0;
            audiomanager.instance.Play("Boss死了");
            ani.SetBool("isdie", true);
        }

        //判断是否碰到敌人，导致死亡扣血
        if (collision.collider.tag == "enemy")
        {
            hp = 0;
            audiomanager.instance.Play("Boss死了");
            ani.SetBool("isdie", true);
        }

    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        //判断是否触地
        if (collision.collider.tag == "ground")
        {
            isGround = false;
        }
        ani.SetBool("isjump", true);
    }

    //判断是否触碰到金币，使之数量+1
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("coin"))
        {
            coin_num += 1;
            coin_text.text = "×" + coin_num;
        }
    }
}
