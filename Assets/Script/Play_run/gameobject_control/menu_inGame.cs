using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu_inGame : MonoBehaviour
{
    //获取暂停UI,game_over物品
    public GameObject pause_button;
    public GameObject gameover_menu;
    public GameObject settingUI;

    //是否播放BGM判断
    public static bool is_play_bgm=true;
    public static bool isPause = false;
    public bool issetting = false;
    
    void Start()
    {
        data_reset();
    }

    void Update()
    {
        //ESC暂停游戏
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!issetting)
            {
                if (!isPause)
                {
                    Pause();
                }
                else
                {
                    Continue();
                }
            }
            else
            {
                Setting();
            }

        }
    }

    //回到主界面函数
    public void back_menu()
    {
        SceneManager.LoadScene("log_in");
    }

    //退出游戏函数
    public void to_exit()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    //暂停游戏函数
    public void Pause()
    {
        if (Time.timeScale == 1)
        {
            //激活物品，使其可以看见
            pause_button.SetActive(true);
            gameover_menu.SetActive(true);

            //暂停BGM
            audiomanager.instance.pause_music();
            is_play_bgm = false;
            isPause = true;

            //暂停游戏时间
            Time.timeScale = 0;

        }
    }

    //继续游戏函数
    public void Continue()
    {
        //初始化物品激活状态
        pause_button.SetActive(false);
        gameover_menu.SetActive(false);

        //继续播放BGM
        audiomanager.instance.continue_music();
        is_play_bgm = true;
        isPause = false;

        //继续游戏时间
        Time.timeScale=1;
    }

    //重启游戏函数
    public void restar()
    {
        Continue();
        SceneManager.LoadScene("Sample_Play");
    }

    //关闭吸引
    public void close_attract()
    {
        magnet_comtrol.is_attract = false;
    }

    //延迟调用close_attract
    public void close_attract_invoke()
    {
        Invoke("close_attract", 5f);
    }

    //重置参数函数
    public void data_reset()
    {
        //初始化物品激活状态
        pause_button.SetActive(false);
        gameover_menu.SetActive(false);
        settingUI.SetActive(false);

        //继续播放BGM
        audiomanager.instance.continue_music();
        is_play_bgm = true;
        isPause = false;
        issetting = false;

        //继续游戏时间
        Time.timeScale = 1;

        magnet_comtrol.is_attract = false;
    }


    //设置按钮函数
    public void Setting()
    {
        issetting = !issetting;
        settingUI.SetActive(issetting);
    }


}
