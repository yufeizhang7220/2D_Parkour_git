using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class over_coin : MonoBehaviour
{
    private TMP_Text over_coin_num;
    // Start is called before the first frame update
    void Start()
    {
        over_coin_num = GetComponent<TMP_Text>();
        //输出死亡时金币数量
        over_coin_num.text = "×" + playercontrol.coin_num;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
