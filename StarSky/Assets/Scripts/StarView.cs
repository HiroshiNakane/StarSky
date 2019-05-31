using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarView : MonoBehaviour
{

    Rigidbody2D rb;
    // 移動速度
    float moveSpeed = 6.0f;

    [SerializeField]
    private GameObject starEffectObject;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        rb.velocity = new Vector2(rb.velocity.x, moveSpeed);

        var instantiateEffect = Instantiate(starEffectObject, transform.position, Quaternion.identity) as GameObject;
        Destroy(instantiateEffect, 0.16f);
    }



    void Update()
    {

       /* if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 100);
        }*/
    }

    public void AddForce(Vector2 dir, float force)
    {
        GetComponent<Rigidbody2D>().AddForce(dir * force, ForceMode2D.Impulse);
    }
}
