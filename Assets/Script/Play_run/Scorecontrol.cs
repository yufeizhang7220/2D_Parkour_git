using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Scorecontrol : MonoBehaviour
{
    private float timer = 0;
    public TMP_Text Score;
    float re_time;
    private groundcontrol gc;
    public float re_score = 0f;
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
            if (timer > 0.1)
            {
                re_time += timer;
                re_score = re_time * gc.speed * 2;
                Score.text = "Score:" + re_score.ToString("0");
                timer = 0;
                //Debug.Log(re_score);
            }

        }
    }
}
