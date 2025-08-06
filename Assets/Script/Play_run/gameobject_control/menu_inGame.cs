using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu_inGame : MonoBehaviour
{
    //��ȡ��ͣUI,game_over��Ʒ
    public GameObject pause_button;
    public GameObject gameover_menu;
    public GameObject settingUI;

    //�Ƿ񲥷�BGM�ж�
    public static bool is_play_bgm=true;
    public static bool isPause = false;
    public bool issetting = false;
    
    void Start()
    {
        data_reset();
    }

    void Update()
    {
        //ESC��ͣ��Ϸ
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

    //�ص������溯��
    public void back_menu()
    {
        SceneManager.LoadScene("log_in");
    }

    //�˳���Ϸ����
    public void to_exit()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    //��ͣ��Ϸ����
    public void Pause()
    {
        if (Time.timeScale == 1)
        {
            //������Ʒ��ʹ����Կ���
            pause_button.SetActive(true);
            gameover_menu.SetActive(true);

            //��ͣBGM
            audiomanager.instance.pause_music();
            is_play_bgm = false;
            isPause = true;

            //��ͣ��Ϸʱ��
            Time.timeScale = 0;

        }
    }

    //������Ϸ����
    public void Continue()
    {
        //��ʼ����Ʒ����״̬
        pause_button.SetActive(false);
        gameover_menu.SetActive(false);

        //��������BGM
        audiomanager.instance.continue_music();
        is_play_bgm = true;
        isPause = false;

        //������Ϸʱ��
        Time.timeScale=1;
    }

    //������Ϸ����
    public void restar()
    {
        Continue();
        SceneManager.LoadScene("Sample_Play");
    }

    //�ر�����
    public void close_attract()
    {
        magnet_comtrol.is_attract = false;
    }

    //�ӳٵ���close_attract
    public void close_attract_invoke()
    {
        Invoke("close_attract", 5f);
    }

    //���ò�������
    public void data_reset()
    {
        //��ʼ����Ʒ����״̬
        pause_button.SetActive(false);
        gameover_menu.SetActive(false);
        settingUI.SetActive(false);

        //��������BGM
        audiomanager.instance.continue_music();
        is_play_bgm = true;
        isPause = false;
        issetting = false;

        //������Ϸʱ��
        Time.timeScale = 1;

        magnet_comtrol.is_attract = false;
    }


    //���ð�ť����
    public void Setting()
    {
        issetting = !issetting;
        settingUI.SetActive(issetting);
    }


}
