using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiomanager : MonoBehaviour
{
    public static audiomanager instance;
    private AudioSource player;
    //创建BGM列表
    public AudioClip[] back_music;
    //声明音量
    public float music_volume=0.5f;
    public bool ismuted = false;
    void Start()
    {
        data_reset();
        instance = this;
        //DontDestroyOnLoad(gameObject);
        player = GetComponent<AudioSource>();
        //随机播放一首bgm
        play_bgm();
    }

    void Update()
    {
        //死亡后不再播放
        if (playercontrol.hp == 0)
        {
            player.Stop();
        }
        //一首结束（玩家未死亡，也没有暂停）随机播放歌曲
        if (!player.isPlaying&&playercontrol.hp!=0&&menu_inGame.is_play_bgm==true)
        {
            play_bgm();
        }
    }
    //创建音效播放函数
    public void Play(string name)
    {
        AudioClip clip =Resources.Load<AudioClip>("Music/SFX/"+name);
        player.PlayOneShot(clip);
    }
    //暂停播放函数
    public void pause_music()
    {
        player.Pause();
    }
    //继续播放函数
    public void continue_music()
    {
        player.UnPause();
    }
    //随机播放bgm函数
    public void play_bgm()
    {
        //获得随机播放片段
        player.clip = back_music[Random.Range(0, back_music.Length)];
        //控制音量大小
        player.volume = music_volume;
        player.Play();
    }

    public void MusicMuted()
    {
        player.mute = !ismuted;
    }

    //重置参数函数
    public void data_reset()
    {
        ismuted = false;
        music_volume = 0.5f;
    }
}
