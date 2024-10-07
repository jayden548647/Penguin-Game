using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrollerscript : MonoBehaviour
{
    HelperScript helper;
    

    // Start is called before the first frame update
    void Start()
    {
        helper = gameObject.AddComponent<HelperScript>();
    }

    // Update is called once per frame
    void Update()
    {
        helper.ExtendedRayCollisionCheck(-4, 0);
        helper.ExtendedRayCollisionCheck(4, 0);
       
    }
}
