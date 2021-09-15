using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontTouch : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Wall")
        {
            StartCoroutine(DieAndRespawn());

            Debug.Log("Go Back!");
        }
    }

    IEnumerator DieAndRespawn()
    {
        GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(2.0f);
        transform.position = new Vector3(-10.09f, -3.89f, 0.0f);
        GetComponent<Renderer>().enabled = true;
    }
}
