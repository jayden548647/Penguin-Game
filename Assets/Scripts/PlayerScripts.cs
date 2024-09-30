using JetBrains.Annotations;
using NUnit.Framework.Constraints;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerScripts : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D player;
    public Animator anim;
    public SpriteRenderer sr;
    bool isGrounded = true;
    int collections = 0;
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
     
    }
    bool attacked = false;
   
    private void OnCollisionStay2D(Collision2D collision)
    {
        isGrounded = true;
        attacked = false;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }


   private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "breakable")
        {
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag == "spring")
        {
            player.AddForce(new Vector3(0, 40, 0), ForceMode2D.Impulse);
        }
        if (collision.gameObject.tag == "collectioncheck" && collections < 10)
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "superspring")
        {
            player.AddForce(new Vector3(0, 100, 0), ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "collectable")
        {
            Destroy(other.gameObject);
            collections++;
            print(collections);
        }
    }

    // Update is called once per frame
    void Update()
    {

         
        anim.SetBool("isMoving", false);
        anim.SetBool("jump", false);
        anim.SetBool("falling", false);
        anim.SetBool("isAttacking", false);
        if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("isMoving", true);
            player.velocity = new Vector2(12f, player.velocity.y);
            sr.flipX = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("isMoving", true);
            player.velocity = new Vector2(-12f, player.velocity.y);
            sr.flipX = true;
        }

        if (isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                player.AddForce(new Vector3(0, 15, 0), ForceMode2D.Impulse);
            }
        }
        if (isGrounded == false)
        {
            anim.SetBool("jump", true);
        }
        if (player.velocityY < 0)
        {
            anim.SetBool("jump", false);
            anim.SetBool("falling", true);
        }
        if (Input.GetKey(KeyCode.E))
        {
            if (attacked == false)
            {
                anim.SetBool("isAttacking", true);
                if (player.velocityY < 0 || player.velocityY > 0)
                {
                    player.AddForce(new Vector3(0, 15, 0), ForceMode2D.Impulse);
                    attacked = true;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            player.AddForce(new Vector3(0, -15, 0), ForceMode2D.Impulse);
        }
    }

    public void AttackFrame()
    {
        print("attack!!");
    }
}
