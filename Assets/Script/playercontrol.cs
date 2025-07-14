using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playercontrol : MonoBehaviour
{
    private Rigidbody2D rbody;
    private Animator ani;
    private bool isGround;
    public static int hp=1;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jump();
            }
            
        
        
    }

    public void jump()
    {
        if (isGround == true)
        {
            rbody.AddForce(Vector2.up * 400);
            audiomanager.instance.Play("Ã¯");
        }
            
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "ground")
        {
            isGround = true;
        }
        ani.SetBool("isjump", false);

        if (collision.collider.tag == "die"&&hp>0)
        {
            hp = 0;
            audiomanager.instance.Play("BossÀ¿¡À");
            ani.SetBool("isdie", true);
            Destroy(gameObject);
        }

        if (collision.collider.tag == "enemy")
        {
            hp = 0;
            audiomanager.instance.Play("BossÀ¿¡À");
            ani.SetBool("isdie", true);
        }

    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "ground")
        {
            isGround = false;
        }
        ani.SetBool("isjump", true);
    }

    
}
