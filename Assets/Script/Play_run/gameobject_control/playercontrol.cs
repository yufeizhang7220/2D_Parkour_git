using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

//����һ�������飨����ʱ�䣬�������������
[System.Serializable]
public class player_data
{
    public string time;
    public int coin_num;
    public int score;
}


//����һ���б���������Ϊ��׼��
[System.Serializable]
public class player_data_record
{
    public List<player_data> record = new List<player_data>();
}


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

    //��ʼ�������Լ������б�
    public player_data Data;
    public player_data_record all_record = new player_data_record();

    //��ȡover_menu��Ʒ���Լ�coin_num�ı������groundcontrol���
    public GameObject over_menu;
    public TMP_Text coin_text;
    public groundcontrol ground_control;
    public Scorecontrol score_control;


    //��Ϸ��������

    private void Awake()
    {
        //��������
        load_data();
    }
    void Start()
    {

        rbody = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();

        //��ʼ��hp��coin_num,could_die
        data_reset();

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
            Die();
            if (over_menu != null)
            {
                over_menu.SetActive(true);
            }

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
        if (collision.collider.tag == "die" && hp > 0 || collision.collider.tag == "enemy")
        {
            hp--;
            relive();
            //���󱣴�����
            save_data();
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
            super_jump();
        }

    }

    //��������������

    //���ò�������
    public void data_reset()
    {
        hp = 1;
        coin_num = 0;
        Could_die = true;
    }

    //���亯��
    public void fall()
    {
        //hp = 1;
        //coin_num = 0;
        Could_die = true;
        ground_control.speed = 2f;
        rbody.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;

    }

    //������������
    public void super_jump()
    {
        //�趨Ϊ�������ӿ��ƶ��ٶ�
        Could_die = false;
        ground_control.speed = 5f;
        //ʹy���޷��ƶ����������ȥ��
        rbody.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        //������
        Vector2 pos = transform.position;
        pos.y = 1.5f;
        transform.position = pos;
        //4s����ؽ��亯��
        Invoke("fall", 4f);
    }

    //�����
    public void relive()
    {
        super_jump();

    }

    //��������
    public void Die()
    {
        if (Could_die == true)
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

    //�������ݺ���
    public void generate_data()
    {
        //����
        Data = new player_data();
        //��ֵ
        Data.time = DateTime.Today.ToString("yyyy-MM-dd");
        Data.coin_num = coin_num;
        Data.score = score_control.ap_score;
    }

    //�������ݺ���
    public void save_data()
    {
        //�ȴ�������
        generate_data();

        //��������ӵ��б���
        all_record.record.Add(Data);

        //д��json�ļ�
        string data_json = JsonUtility.ToJson(all_record, true);
        string filepath = Application.streamingAssetsPath + "/player_history_data.json";
        using (StreamWriter sw = new StreamWriter(filepath))
        {
            sw.WriteLine(data_json);
            sw.Close();
            sw.Dispose();
        }
    }

    //�������ݺ���
    public void load_data()
    {

        string filepath = Application.streamingAssetsPath + "/player_history_data.json";
        string json_data;
        //��ȡjson�ļ�
        using (StreamReader sr = new StreamReader(filepath))
        {
            json_data = sr.ReadToEnd();
            //�����ݸ�ֵ��all_record�б���
            all_record = JsonUtility.FromJson<player_data_record>(json_data);
            sr.Close();
        }
    }



   
}
