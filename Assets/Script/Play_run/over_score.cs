using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class over_score : MonoBehaviour
{
    public Scorecontrol s;
    private TMP_Text over_menu;
    // Start is called before the first frame update
    void Start()
    {
        over_menu = GetComponent<TMP_Text>();
        //s = GetComponent<Scorecontrol>();
        over_menu.text = "Score:"+s.re_score.ToString("0") ;
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (s == null)
        {
            Debug.LogError("未找到score组件");
        }
        else
        {
            Debug.Log("已经找到score组件");
        }*/

    }
}
