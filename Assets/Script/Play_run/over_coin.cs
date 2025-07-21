using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class over_coin : MonoBehaviour
{
    //获取自身的组件
    private TMP_Text over_coin_num;

    void Start()
    {
        over_coin_num = GetComponent<TMP_Text>();
        //输出死亡时金币数量
        over_coin_num.text = "×" + playercontrol.coin_num;
    }

    void Update()
    {
        
    }
}
