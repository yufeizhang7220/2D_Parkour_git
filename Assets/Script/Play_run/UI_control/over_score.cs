using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class over_score : MonoBehaviour
{
    // ��ȡscorecontrol��over_menu���
    public Scorecontrol s;
    private TMP_Text over_menu;

    void Start()
    {
        over_menu = GetComponent<TMP_Text>();

        over_menu.text = "����:"+s.ap_score;
        
    }

    void Update()
    {
        

    }
}
