using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Scorecontrol : MonoBehaviour
{
    //获取Score的tmp组件
    public TMP_Text Score;
    
    private groundcontrol gc;

    //建立暂时计时器，真计时器和真分数
    private float timer = 0;
    float re_time = 0;
    public float re_score = 0f;
    public int ap_score ;
    // Start is called before the first frame update
    void Start()
    {
        //获取组件
        gc = FindObjectOfType<groundcontrol>();
        Score = GetComponent<TMP_Text>();
    }

   
    void Update()
    {
        //计时
        if (playercontrol.hp != 0)
        {
            timer += Time.deltaTime;
            //控制每0.1s调用一次
            if (timer > 0.1)
            {
                //记录真实时间，计算真实分数
                re_time += timer;
                re_score = re_time * gc.speed * 2;
                ap_score = (int)re_score;
                //输出
                Score.text = "Score:" + ap_score;
                //重置
                timer = 0;
            }

        }
    }
}
