using JetBrains.Annotations;
using NUnit.Framework.Constraints;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class PlayerScripts : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D player;
    public Animator anim;
    public SpriteRenderer sr;
    bool isGrounded = false;
    int collections = 0;
    public LayerMask groundLayerMask;
    
    

    bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 1.0f;
        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayerMask);
        if (hit.collider != null)
        {
            return true;
        }
        return false;
    }


    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        groundLayerMask = LayerMask.GetMask("Ground");
        
    }
    bool attacked = false;


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
        if (collision.gameObject.tag == "collectioncheck" && collections <= 10)
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "superspring")
        {
            player.AddForce(new Vector3(0, 100, 0), ForceMode2D.Impulse);
        }
        if (collision.gameObject.tag == "collectioncheck2" && collections >= 14)
        {
            Destroy(collision.gameObject);
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
        sr.color = Color.white;
         
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
        if (player.velocityY < 0 || player.velocityY > 0)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                player.AddForce(new Vector3(0, -15, 0), ForceMode2D.Impulse);
            }
        }

        if (player.position.y < -800)
        {
            sr.color = Color.black;
        }

        DoRayCollisionCheck();
      
    }
    public void DoRayCollisionCheck()
    {
        float rayLength = 1f; // length of raycast


        //cast a ray downward 
        RaycastHit2D hit;

        hit = Physics2D.Raycast(transform.position, Vector2.down, rayLength, groundLayerMask);

        Color hitColor = Color.red;


        if (hit.collider != null)
        {
            hitColor = Color.green;
            isGrounded = true;
            attacked = false;
        }
        // draw a debug ray to show ray position
        // You need to enable gizmos in the editor to see these
        Debug.DrawRay(transform.position, Vector2.down * rayLength, hitColor);

    }

}
