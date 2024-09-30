using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_script : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject player;
    public SpriteRenderer spriteRenderer;
   
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float px = player.transform.position.x;
        float ex = transform.position.x;
        if (player.transform.position.y < -900)
        {
            if (ex > px + 25)
            {
                spriteRenderer.flipX = true;
                rb.velocity = new Vector2(-25, rb.velocity.y);
            }
            if (px - 37 > ex)
            {
                spriteRenderer.flipX = false;
                rb.velocity = new Vector2(25, rb.velocity.y);
            }
        }
    }
}
