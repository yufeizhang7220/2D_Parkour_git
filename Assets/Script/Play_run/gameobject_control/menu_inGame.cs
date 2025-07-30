using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu_inGame : MonoBehaviour
{
    //��ȡ��ͣUI,game_over��Ʒ
    public GameObject pause_button;
    public GameObject gameover_menu;

    //�Ƿ񲥷�BGM�ж�
    public static bool is_play_bgm=true;
    
    void Start()
    {
        
    }

    void Update()
    {
        //ESC��ͣ��Ϸ
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
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

   
}
