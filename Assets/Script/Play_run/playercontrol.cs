using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playercontrol : MonoBehaviour
{
    private Rigidbody2D rbody;
    private Animator ani;
    private bool isGround;
    public static int hp=1;
    public GameObject over_menu;
    float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        
            over_menu.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //ø’∏Ò≈–∂œÃ¯‘æ
       if (Input.GetKeyDown(KeyCode.Space))
       {
                jump();
       }
       //À¿ÕˆΩÁ√ÊÃ¯◊™
        if (hp == 0)
        {
            if (over_menu != null)
            {
                over_menu.SetActive(true);
            }

        }

        
        
    }
    //Ã¯‘æπ¶ƒ‹
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
        //≈–∂œ «∑Ò¥•µÿ
        if (collision.collider.tag == "ground")
        {
            isGround = true;
        }
        ani.SetBool("isjump", false);
        //≈–∂œ «∑Ò≥ˆΩÁ£¨µº÷¬ø€—™£¨À¿Õˆ
        if (collision.collider.tag == "die"&&hp>0)
        {
            hp = 0;
            audiomanager.instance.Play("BossÀ¿¡À");
            ani.SetBool("isdie", true);
        }
        //≈–∂œ «∑Ò≈ˆµΩµ–»À£¨µº÷¬À¿Õˆø€—™
        if (collision.collider.tag == "enemy")
        {
            hp = 0;
            audiomanager.instance.Play("BossÀ¿¡À");
            ani.SetBool("isdie", true);
        }

    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        //≈–∂œ «∑Ò¥•µÿ
        if (collision.collider.tag == "ground")
        {
            isGround = false;
        }
        ani.SetBool("isjump", true);
    }

    
}
