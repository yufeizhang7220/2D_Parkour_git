using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class over_coin : MonoBehaviour
{
    //��ȡ��������
    private TMP_Text over_coin_num;

    void Start()
    {
        over_coin_num = GetComponent<TMP_Text>();
        //�������ʱ�������
        over_coin_num.text = "��" + playercontrol.coin_num;
    }

    void Update()
    {
        
    }
}
