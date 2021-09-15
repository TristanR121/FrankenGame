using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousemove : MonoBehaviour
{
    //Aaron Movement Code
    //Son Hammer Code
        //Kept code for movement the same
        //Added pickaxe code along with hammer

    //variables
    public GameObject hammer;
    public GameObject pickaxe;
    public float speed = 5f;
    private Vector3 mousePos;


    void Start()
    {
        //sets object position to mouse position
        mousePos = transform.position;
    }

    void Update()
    {
        //https://stackoverflow.com/questions/46078829/slowly-moving-gameobject-to-mouse-position for the mouse mechanic
        //every time mouse is pressed/clicked the object moves closer to the mouse
        if (Input.GetMouseButton(0))
        {
            if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x > mousePos.x)
                mousePos.x = mousePos.x + speed * Time.deltaTime;
            if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < mousePos.x)
                mousePos.x = mousePos.x - speed * Time.deltaTime;
            if (Camera.main.ScreenToWorldPoint(Input.mousePosition).y > mousePos.y)
                mousePos.y = mousePos.y + speed * Time.deltaTime;
            if (Camera.main.ScreenToWorldPoint(Input.mousePosition).y < mousePos.y)
                mousePos.y = mousePos.y - speed * Time.deltaTime;
            transform.position = mousePos;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (hammer.transform.parent != null) // check if player is holding hammer or not
            {
                hammer.transform.parent = null; // drop
                hammer.transform.position = new Vector2(transform.position.x, transform.position.y - 1f);
                transform.name = "Player";
            }
            else
            {
                Debug.Log("You dropped it");
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (pickaxe.transform.parent != null) // check if player is holding hammer or not
                {
                    pickaxe.transform.parent = null; // drop
                    pickaxe.transform.position = new Vector2(transform.position.x, transform.position.y - 1f);
                    transform.name = "Player";
                }
                else
                {
                    Debug.Log("You dropped it");
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "hammer")
        {
            hammer.transform.SetParent(transform); // pick up
            hammer.transform.position = new Vector2(transform.position.x + 0.75f, transform.position.y - 0.5f);
            transform.name = "PwHammer";
        }

        if (collision.gameObject.tag == "Pickaxe")
        {
            pickaxe.transform.SetParent(transform); // pick up
            pickaxe.transform.position = new Vector2(transform.position.x + 0.35f, transform.position.y + 0.4f);
            transform.name = "PwPickaxe";
        }
    }
}
