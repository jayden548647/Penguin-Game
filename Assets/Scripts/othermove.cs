using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class othermove : MonoBehaviour
   
    
{
    Rigidbody2D item;
    
    // Start is called before the first frame update
    void Start()
    {
        item = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "spring")
        {
            item.AddForce(new Vector3(0, 20, 0), ForceMode2D.Impulse);
        }
    }
        // Update is called once per frame
        void Update()
    {
        
    }
}
