using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;

public class history_control : MonoBehaviour
{
    public List<int> number = new List<int>();
    public player_data_record all_record = new player_data_record();

    public List<Transform> Trans_grandchild = new List<Transform>();
    public List<List<Transform>> Trans_child = new List<List<Transform>>();
    public TMP_Text TEXT;

    public GameObject content;
    
    void Start()
    {
        load_data();
        number=sort_record();
        Transform con = content.GetComponent<Transform>();
        for (int i = 0; i < 3; i++)
        {
            var currentRecordElements = new List<Transform>
            {
                con.Find("record (" + (i + 1) + ")/number"),
                con.Find("record (" + (i + 1) + ")/DATE"),
                con.Find("record (" + (i + 1) + ")/SCORE"),
                con.Find("record (" + (i + 1) + ")/COIN")
            };
            Trans_child.Add(currentRecordElements);
        }
        for(int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 4; j++)
            {
                TEXT=Trans_child[i][j].GetComponent<TMP_Text>();
                if (j == 0)
                {
                    TEXT.text = (i + 1).ToString();
                }
                else
                {
                    switch (j)
                    {
                        case 1:
                            TEXT.text = all_record.record[number[i]].time;
                            break;
                        case 2:
                            TEXT.text = all_record.record[number[i]].score.ToString();
                            break;
                        case 3:
                            TEXT.text = all_record.record[number[i]].coin_num.ToString();
                            break;

                    }
                }
            }
        }
        


    }

    
    void Update()
    {
        
    }

    public void load_data()
    {

        string filepath = Application.streamingAssetsPath + "/player_history_data.json";
        string json_data;
        //读取json文件
        using (StreamReader sr = new StreamReader(filepath))
        {
            json_data = sr.ReadToEnd();
            sr.Close();
        }
        //将数据赋值到all_record列表中
        all_record = JsonUtility.FromJson<player_data_record>(json_data);
    }

    

    public List<int> sort_record()
    {
        var topThree = new SortedSet<(int score, int index)>(
            Comparer<(int score, int index)>.Create((a, b) =>
                a.score == b.score ? a.index.CompareTo(b.index) : a.score.CompareTo(b.score))
        );

        // 找出最大的三个元素（分数升序排列）
        for (int i = 0; i < all_record.record.Count; i++)
        {
            var current = (score: all_record.record[i].score, index: i);

            if (topThree.Count < 3)
            {
                topThree.Add(current);
            }
            else if (current.score > topThree.Min.score)
            {
                topThree.Remove(topThree.Min);
                topThree.Add(current);
            }
        }

        // 按分数降序排列，并提取索引
        return topThree
            .OrderByDescending(item => item.score)  // 按分数降序
            .Select(item => item.index)             // 提取索引
            .ToList();
    }
}
