using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    private float timer = 0;
    public TMP_Text Score;
    float re_time;
    private groundcontrol gc;
    // Start is called before the first frame update
    void Start()
    {
        gc = FindObjectOfType<groundcontrol>();
        Score = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playercontrol.hp != 0)
        {
            timer += Time.deltaTime;
            if (timer>0.1)
            {
                re_time += timer;
                Score.text = "Score:" +(re_time*gc.speed*100).ToString("0");
                timer = 0;
            }
            
        }
    }
}
