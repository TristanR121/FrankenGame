using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    public Rigidbody2D rb;
    bool active = false;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        rb.isKinematic = true;
        if (active == true)
        {
            rb.isKinematic = false;
        }
    }
    // Pick up daimonds only with the pickaxe
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "PwPickaxe")
        {
            active = true;
            Destroy(gameObject);

        }

    }
}
