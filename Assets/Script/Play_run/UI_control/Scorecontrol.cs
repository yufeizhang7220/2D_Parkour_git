using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Scorecontrol : MonoBehaviour
{
    //��ȡScore��tmp���
    public TMP_Text Score;
    
    private groundcontrol gc;

    //������ʱ��ʱ�������ʱ���������
    private float timer = 0;
    float re_time = 0;
    public float re_score = 0f;
    public int ap_score ;
    // Start is called before the first frame update
    void Start()
    {
        //��ȡ���
        gc = FindObjectOfType<groundcontrol>();
        Score = GetComponent<TMP_Text>();
    }

   
    void Update()
    {
        //��ʱ
        if (playercontrol.hp != 0)
        {
            timer += Time.deltaTime;
            //����ÿ0.1s����һ��
            if (timer > 0.1)
            {
                //��¼��ʵʱ�䣬������ʵ����
                re_time += timer;
                re_score = re_time * gc.speed * 2;
                ap_score = (int)re_score;
                //���
                Score.text = "Score:" + ap_score;
                //����
                timer = 0;
            }

        }
    }
}
