using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

//声明一个数据组（包含时间，金币数，分数）
[System.Serializable]
public class player_data
{
    public string time;
    public int coin_num;
    public int score;
}


//声明一个列表（以数据组为基准）
[System.Serializable]
public class player_data_record
{
    public List<player_data> record = new List<player_data>();
}


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

    //初始化数据以及数据列表
    public player_data Data;
    public player_data_record all_record = new player_data_record();

    //获取over_menu物品，以及coin_num文本组件和groundcontrol组件
    public GameObject over_menu;
    public TMP_Text coin_text;
    public groundcontrol ground_control;
    public Scorecontrol score_control;


    //游戏函数调用

    private void Awake()
    {
        //加载数据
        load_data();
    }
    void Start()
    {

        rbody = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();

        //初始化hp，coin_num,could_die
        data_reset();

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
            Die();
            if (over_menu != null)
            {
                over_menu.SetActive(true);
            }

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
        if (collision.collider.tag == "die" && hp > 0 || collision.collider.tag == "enemy")
        {
            hp--;
            relive();
            //死后保存数据
            save_data();
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
            super_jump();
        }

    }

    //各个函数的申明

    //重置参数函数
    public void data_reset()
    {
        hp = 1;
        coin_num = 0;
        Could_die = true;
    }

    //降落函数
    public void fall()
    {
        //hp = 1;
        //coin_num = 0;
        Could_die = true;
        ground_control.speed = 2f;
        rbody.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;

    }

    //超级大跳函数
    public void super_jump()
    {
        //设定为不死，加快移动速度
        Could_die = false;
        ground_control.speed = 5f;
        //使y轴无法移动（不会掉下去）
        rbody.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        //飞起来
        Vector2 pos = transform.position;
        pos.y = 1.5f;
        transform.position = pos;
        //4s后加载降落函数
        Invoke("fall", 4f);
    }

    //复活函数
    public void relive()
    {
        super_jump();

    }

    //死亡函数
    public void Die()
    {
        if (Could_die == true)
        {
            hp = 0;
            audiomanager.instance.Play("Boss死了");
            ani.SetBool("isdie", true);
        }
    }

    //跳跃函数
    public void jump()
    {
        if (isGround == true)
        {
            rbody.AddForce(Vector2.up * 400);
            audiomanager.instance.Play("跳");
        }

    }

    //生成数据函数
    public void generate_data()
    {
        //创建
        Data = new player_data();
        //赋值
        Data.time = DateTime.Today.ToString("yyyy-MM-dd");
        Data.coin_num = coin_num;
        Data.score = score_control.ap_score;
    }

    //保存数据函数
    public void save_data()
    {
        //先创建数据
        generate_data();

        //将数据添加到列表中
        all_record.record.Add(Data);

        //写入json文件
        string data_json = JsonUtility.ToJson(all_record, true);
        string filepath = Application.streamingAssetsPath + "/player_history_data.json";
        using (StreamWriter sw = new StreamWriter(filepath))
        {
            sw.WriteLine(data_json);
            sw.Close();
            sw.Dispose();
        }
    }

    //加载数据函数
    public void load_data()
    {

        string filepath = Application.streamingAssetsPath + "/player_history_data.json";
        string json_data;
        //读取json文件
        using (StreamReader sr = new StreamReader(filepath))
        {
            json_data = sr.ReadToEnd();
            //将数据赋值到all_record列表中
            all_record = JsonUtility.FromJson<player_data_record>(json_data);
            sr.Close();
        }
    }



   
}
