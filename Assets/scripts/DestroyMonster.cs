using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMonster : MonoBehaviour
{
   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {

            Destroy(gameObject);

        }
        if (collision.transform.tag == "floor")
        {

            Destroy(gameObject);

        }
    }
   
}
