using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class super_jump_control : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //碰到大跳时，发出声音，并且销毁
        audiomanager.instance.Play("金币");
        Destroy(gameObject);
    }
}
