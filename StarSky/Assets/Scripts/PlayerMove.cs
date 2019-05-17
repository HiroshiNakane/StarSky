using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    Rigidbody rb;
    // 移動速度
    float moveSpeed = 4.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // プレイヤーの座標の取得
        Vector3 playerPos = GameObject.Find("Player").transform.position;

        // タップした座標の取得
        Vector3 tapPosScreen = Input.mousePosition;
        tapPosScreen.z = 10;
        Vector3 tapPosWorld = Camera.main.ScreenToWorldPoint(tapPosScreen);
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(rb.velocity.x, moveSpeed);
    }

    void Update()
    {
        
    }
}
