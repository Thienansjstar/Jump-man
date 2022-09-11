using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterControl : MonoBehaviour
{

    Rigidbody2D rb;
    GameObject target;
    public float moveSpeed;
    Vector2 directionToTarget;
    public float test;
    public float poo;
    
 
    void Start()
    {
        target = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        
    }

    
    void Update()
    {
        MoveMonster();
        
    }

   
    void MoveMonster ()
    {
        if (target != null)
        {
            directionToTarget = (target.transform.position - transform.position).normalized;
            rb.velocity = new Vector2(directionToTarget.x * moveSpeed,
                                        directionToTarget.y * moveSpeed);
            Debug.Log(rb.velocity);
           poo = 5 * Mathf.Sin(test);

        }else
        rb.velocity = Vector3.zero;
    }

}
