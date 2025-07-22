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
    private bool Could_die = true;

    //��̬����Ѫ�����������
    public static int hp=1;
    public static int coin_num = 0;


    //��ȡover_menu��Ʒ���Լ�coin_num�ı������groundcontrol���
    public GameObject over_menu;
    public TMP_Text coin_text;
    public groundcontrol ground_control;
    
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

    //��������
    public void Die()
    {
        if (Could_die==true)
        {
            hp = 0;
            audiomanager.instance.Play("Boss����");
            ani.SetBool("isdie", true);
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

        //�ж��Ƿ����,�Ƿ��������ˣ����¿�Ѫ������
        if (collision.collider.tag == "die"&&hp>0|| collision.collider.tag == "enemy")
        {
            Die();
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

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�ж��Ƿ�������ң�ʹ֮����+1
        if (collision.CompareTag("coin"))
        {
            coin_num += 1;
            coin_text.text = "��" + coin_num;
        }

        //7s��������״̬
        if (collision.CompareTag("super_jump"))
        {
            //�趨Ϊ�������ӿ��ƶ��ٶ�
            Could_die = false;
            ground_control.speed = 5f;
            //ʹy���޷��ƶ����������ȥ��
            rbody.constraints = RigidbodyConstraints2D.FreezePositionY|RigidbodyConstraints2D.FreezeRotation;
            //������
            Vector2 pos = transform.position;
            pos.y = 1.5f;
            transform.position = pos;
            //4s����ؽ��亯��
            Invoke("fall", 4f);
        }
        
    }

    //���亯��
    public void fall()
    {
        Could_die = true;
        ground_control.speed = 2f;
        rbody.constraints = RigidbodyConstraints2D.FreezeRotation;

    }



}
