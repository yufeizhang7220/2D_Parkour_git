using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class audiomanager : MonoBehaviour
{
    //��������������һ������
    public static audiomanager instance;
    private AudioSource player;
    public Slider music_volume_setting;
    //����BGM�б�
    public AudioClip[] back_music;
    //��������
    public static float music_volume=0.5f;
    public bool ismuted = false;
    void Start()
    {
        //��������
        data_reset();

        //��ȡ���
        instance = this;
        if (instance == null)
        {
            Debug.LogError("û���������ֵ���");
        }
        
        player = GetComponent<AudioSource>();
        if (player == null)
        {
            Debug.LogError("û���ҵ�������");
        }

        //�������һ��bgm
        play_bgm();
    }

    void Update()
    {
        //�������ٲ���
        if (playercontrol.hp == 0)
        {
            player.Stop();
        }
        //һ�׽��������δ������Ҳû����ͣ��������Ÿ���
        if (!player.isPlaying&&playercontrol.hp!=0&&menu_inGame.is_play_bgm==true)
        {
            play_bgm();
        }
    }
    //������Ч���ź���
    public void Play(string name)
    {
        AudioClip clip =Resources.Load<AudioClip>("Music/SFX/"+name);
        player.PlayOneShot(clip);
    }
    //��ͣ���ź���
    public void pause_music()
    {
        player.Pause();
    }
    //�������ź���
    public void continue_music()
    {
        player.UnPause();
    }
    //�������bgm����
    public void play_bgm()
    {
        //����������Ƭ��
        player.clip = back_music[Random.Range(0, back_music.Length)];
        //����������С
        player.volume = music_volume;
        player.Play();
    }

    public void MusicMuted()
    {
        player.mute = !ismuted;
    }

    //���ò�������
    public void data_reset()
    {
        ismuted = false;
        music_volume = 0.5f;
    }

    //��������
    public void musicMuted()
    {
        ismuted = !ismuted;
        player.mute = ismuted;
    }

    public void change_volume()
    {
        if (music_volume_setting == null)
        {
            Debug.LogError("�Ҳ�����������");
        }
        else
        {
            music_volume = music_volume_setting.value;
            player.volume = music_volume;
            Play("���");
        }
            
    }
}
