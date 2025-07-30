using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class right_up_control : MonoBehaviour
{
    public Image[] hearts;
    void Start()
    {
        
    }

    void Update()
    {
        for(int i = 0; i < playercontrol.hp; i++)
        {
            hearts[i].color = Color.white;
            Debug.Log("第" + i + "个亮了");
        }
        for(int i = playercontrol.hp; i < 3; i++)
        {
            hearts[i].color = new Color(0,0,0);
            Debug.Log("第" + i + "个暗了");
        }
    }
}
