using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_script : MonoBehaviour
{
    public Transform player;
    public SpriteRenderer sr;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float py = player.position.y;
        sr.color = Color.white;
        transform.position = player.transform.position + new Vector3(-70, 35, -5);
        if (py < -800)
        {
            sr.color = Color.red;
        }
    }
}
