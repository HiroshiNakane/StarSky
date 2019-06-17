using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingMeteorites : MonoBehaviour
{

    Rigidbody rb;

    public float fallSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        rb.velocity = new Vector3(rb.velocity.x, fallSpeed, rb.velocity.z);

    }
}
