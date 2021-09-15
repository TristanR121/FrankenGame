using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakWall : MonoBehaviour
{

    //Son hammer code

    public Rigidbody2D rb;
    bool active = false;

    void Start()
    {
        //Set rigidbody of breakwall
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //allow for wall to be moved if hammer is picked up.
        rb.isKinematic = true;
        if (active == true)
        {
            rb.isKinematic = false;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "PwHammer")
        {            
            active = true;
        }
    }


}
