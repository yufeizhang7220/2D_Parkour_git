using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //��ʼ��Ϸ
    public void start_run()
    {
        //����PLAY���������ҳ�ʼ��hp���Լ��������
        SceneManager.LoadScene("Sample_Play");
        playercontrol.hp = 1;
        playercontrol.coin_num = 0;
    }
    //������Ϸ
    public void exit()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void history()
    {
        SceneManager.LoadScene("history");
    }

    public void to_Menu()
    {
        SceneManager.LoadScene("log_in");
    }
}
