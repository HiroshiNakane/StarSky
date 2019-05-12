using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    Rigidbody rb;
    float moveSpeed = 4.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(rb.velocity.x, moveSpeed);
    }

    void Update()
    {
        
    }
}
