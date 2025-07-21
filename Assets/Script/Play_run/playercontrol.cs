using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playercontrol : MonoBehaviour
{
    //��ȡ�������
    private Rigidbody2D rbody;
    private Animator ani;

    //�ж��Ƿ񴥵�
    private bool isGround;

    //��̬����Ѫ�����������
    public static int hp=1;
    public static int coin_num = 0;

    //��ȡover_menu��Ʒ���Լ�coin_num���ı����
    public GameObject over_menu;
    public TMP_Text coin_text;
    
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();

        //��ʼ��hp��coin_num
        hp = 1;
        coin_num = 0;
        
        
    }

    void Update()
    {
        
        //�ո��ж���Ծ
       if (Input.GetKeyDown(KeyCode.Space))
       {
                jump();
       }
       //����������ת
        if (hp == 0)
        {
            if (over_menu != null)
            {
                over_menu.SetActive(true);
            }

        }        
    }

    //��Ծ����
    public void jump()
    {
        if (isGround == true)
        {
            rbody.AddForce(Vector2.up * 400);
            audiomanager.instance.Play("��");
        }
            
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�ж��Ƿ񴥵�
        if (collision.collider.tag == "ground")
        {
            isGround = true;
        }
        ani.SetBool("isjump", false);

        //�ж��Ƿ���磬���¿�Ѫ������
        if (collision.collider.tag == "die"&&hp>0)
        {
            hp = 0;
            audiomanager.instance.Play("Boss����");
            ani.SetBool("isdie", true);
        }

        //�ж��Ƿ��������ˣ�����������Ѫ
        if (collision.collider.tag == "enemy")
        {
            hp = 0;
            audiomanager.instance.Play("Boss����");
            ani.SetBool("isdie", true);
        }

    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        //�ж��Ƿ񴥵�
        if (collision.collider.tag == "ground")
        {
            isGround = false;
        }
        ani.SetBool("isjump", true);
    }

    //�ж��Ƿ�������ң�ʹ֮����+1
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("coin"))
        {
            coin_num += 1;
            coin_text.text = "��" + coin_num;
        }
    }
}
