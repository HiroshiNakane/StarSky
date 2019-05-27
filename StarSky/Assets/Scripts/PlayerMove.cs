using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    Rigidbody rb;
    // 移動速度
    float moveSpeed = 4.0f;

    Vector3 playerPos;

    int time;
    Text countTimerText;

    void Start()
    {

        StartCoroutine(StartCountCoroutine());

        rb = GetComponent<Rigidbody>();

        // プレイヤーの座標の取得
        //playerPos = GameObject.Find("Player").transform.position;

        // タップした座標の取得
        /*Vector3 tapPosScreen = Input.mousePosition;
        tapPosScreen.z = 10;
        Vector3 tapPosWorld = Camera.main.ScreenToWorldPoint(tapPosScreen);*/
    }

    IEnumerator StartCountCoroutine()
    {
        yield return new WaitForSeconds(1.0f);


    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(rb.velocity.x, moveSpeed);
    }

    void Update()
    {
        Moving();

        playerPos = GameObject.Find("Player").transform.position;

        if (Input.GetMouseButtonDown(0))
        {   // タップしたx座標がPlayerのx座標より左か右かをログで確認
            if (Input.mousePosition.x - 97.0f > playerPos.x)
            {
                Debug.Log("+");
            }
            else
            {
                Debug.Log("-");
            }

        }
    }

    void Moving()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //preMousePos = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            playerPos.x = 97.0f;
            Vector3 mousePosDiff = Input.mousePosition - playerPos;
            //preMousePos = Input.mousePosition;
            Vector3 newPos = this.gameObject.transform.position + new Vector3(mousePosDiff.x / Screen.width, 0 / Screen.height, 0) * 0.3f;

            this.transform.position = newPos;
        }
    }
}
