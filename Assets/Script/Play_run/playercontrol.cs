using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playercontrol : MonoBehaviour
{
    private Rigidbody2D rbody;
    private Animator ani;
    private bool isGround;
    //��̬����Ѫ�����������
    public static int hp=1;
    public static int coin_num = 0;

    public GameObject over_menu;
    public TMP_Text coin_text;
    
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        
        
        
    }

    // Update is called once per frame
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("coin"))
        {
            coin_num += 1;
            coin_text.text = "��" + coin_num;
        }
    }
}
