using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class over_score : MonoBehaviour
{
    // 获取scorecontrol，over_menu组件
    public Scorecontrol s;
    private TMP_Text over_menu;

    void Start()
    {
        over_menu = GetComponent<TMP_Text>();

        over_menu.text = "分数:"+s.ap_score;
        
    }

    void Update()
    {
        

    }
}
