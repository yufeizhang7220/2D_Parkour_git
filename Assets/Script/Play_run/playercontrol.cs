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
    private bool Could_die = true;

    //静态申明血量，金币数量
    public static int hp=1;
    public static int coin_num = 0;


    //获取over_menu物品，以及coin_num文本组件和groundcontrol组件
    public GameObject over_menu;
    public TMP_Text coin_text;
    public groundcontrol ground_control;
    
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

    //死亡函数
    public void Die()
    {
        if (Could_die==true)
        {
            hp = 0;
            audiomanager.instance.Play("Boss死了");
            ani.SetBool("isdie", true);
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

        //判断是否出界,是否碰到敌人，导致扣血，死亡
        if (collision.collider.tag == "die"&&hp>0|| collision.collider.tag == "enemy")
        {
            Die();
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

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //判断是否触碰到金币，使之数量+1
        if (collision.CompareTag("coin"))
        {
            coin_num += 1;
            coin_text.text = "×" + coin_num;
        }

        //7s超级大跳状态
        if (collision.CompareTag("super_jump"))
        {
            //设定为不死，加快移动速度
            Could_die = false;
            ground_control.speed = 5f;
            //使y轴无法移动（不会掉下去）
            rbody.constraints = RigidbodyConstraints2D.FreezePositionY|RigidbodyConstraints2D.FreezeRotation;
            //飞起来
            Vector2 pos = transform.position;
            pos.y = 1.5f;
            transform.position = pos;
            //4s后加载降落函数
            Invoke("fall", 4f);
        }
        
    }

    //降落函数
    public void fall()
    {
        Could_die = true;
        ground_control.speed = 2f;
        rbody.constraints = RigidbodyConstraints2D.FreezeRotation;

    }



}
