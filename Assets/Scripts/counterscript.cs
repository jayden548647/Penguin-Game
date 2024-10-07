using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class counterscript : MonoBehaviour
{
    
    public int collections;
    public Transform player;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("0", false);
        anim.SetBool("1", false);
        anim.SetBool("2", false);
        anim.SetBool("3", false);
        anim.SetBool("4", false);
        anim.SetBool("5", false);
        anim.SetBool("6", false);
        anim.SetBool("7", false);
        anim.SetBool("8", false);
        anim.SetBool("9", false);
        anim.SetBool("10", false);
        anim.SetBool("11", false);
        anim.SetBool("12", false);
        anim.SetBool("13", false);
        anim.SetBool("14", false);



        transform.position = player.transform.position + new Vector3(-60, 35, -5);


        if(collections == 0)
        {
            anim.SetBool("0", true);
        }
        if (collections == 1)
        {
            anim.SetBool("1", true);
        }
        if (collections == 2)
        {
            anim.SetBool("2", true);
        }
        if (collections == 3)
        {
            anim.SetBool("3", true);
        }
        if (collections == 4)
        {
            anim.SetBool("4", true);
        }
        if (collections == 5)
        {
            anim.SetBool("5", true);
        }
        if (collections == 6)
        {
            anim.SetBool("6", true);
        }
        if (collections == 7)
        {
            anim.SetBool("7", true);
        }
        if (collections == 8)
        {
            anim.SetBool("8", true);
        }
        if (collections == 9)
        {
            anim.SetBool("9", true);
        }
        if (collections == 10)
        {
            anim.SetBool("10", true);
        }
        if (collections == 11)
        {
            anim.SetBool("11", true);
        }
        if (collections == 12)
        {
            anim.SetBool("12", true);
        }
        if (collections == 13)
        {
            anim.SetBool("13", true);
        }
        if (collections == 14)
        {
            anim.SetBool("14", true);
        }
    }
}
