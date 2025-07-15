using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiomanager : MonoBehaviour
{
    public static audiomanager instance;
    private AudioSource player;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        player = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play(string name)
    {
        AudioClip clip =Resources.Load<AudioClip>(name);
        player.PlayOneShot(clip);
    }
}
