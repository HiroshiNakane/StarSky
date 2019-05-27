using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarView : MonoBehaviour
{

    Rigidbody2D rb;
    // 移動速度
    float moveSpeed = 4.0f;

    void Start()
    {

    }


    void FixedUpdate()
    {
        rb.velocity = new Vector2(rb.velocity.x, moveSpeed);
    }

    void Update()
    {
        
    }

    public void AddForce(Vector2 dir, float force)
    {
        GetComponent<Rigidbody2D>().AddForce(dir * force, ForceMode2D.Impulse);
    }
}
