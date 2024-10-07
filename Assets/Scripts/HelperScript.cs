using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class HelperScript : MonoBehaviour
{
    public LayerMask groundLayerMask;
    public SpriteRenderer sr;
    public Rigidbody2D skeleton;
    int skeledir = -1;
    int collections = 0;
    


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

    






    // Start is called before the first frame update
    void Start()
    {
        groundLayerMask = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame
    void Update()
    {

    }




    public bool ExtendedRayCollisionCheck(float xoffs, float yoffs)
    {
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
        Rigidbody2D skeleton = gameObject.GetComponent<Rigidbody2D>();
        float rayLength = 1f; // length of raycast
        bool hitSomething = false;
        

        // convert x and y offset into a Vector3 
        Vector3 offset = new Vector3(xoffs, yoffs, 0);

        //cast a ray downward 
        RaycastHit2D hit;


        hit = Physics2D.Raycast(transform.position + offset, -Vector2.up, rayLength, groundLayerMask);

        Color hitColor = Color.white;


        if (hit.collider != null)
        {
            hitColor = Color.green;
            hitSomething = true;
            skeledir = -skeledir;
        }
        if (skeledir < 0)
        {
            sr.flipX = false;
            skeleton.velocity = new Vector2(-12f, skeleton.velocity.y);
        }
        if (skeledir > 0)
        {
            sr.flipX = true;
            skeleton.velocity = new Vector2(12f, skeleton.velocity.y);
        }
        // draw a debug ray to show ray position
        // You need to enable gizmos in the editor to see these
        Debug.DrawRay(transform.position + offset, -Vector3.up * rayLength, hitColor);

        return hitSomething;

       
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
        }
        // draw a debug ray to show ray position
        // You need to enable gizmos in the editor to see these
        Debug.DrawRay(transform.position, Vector2.down * rayLength, hitColor);
    }
    
}