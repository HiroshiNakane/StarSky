using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartText : MonoBehaviour
{
    float speed = 0.7f;

    private Text text;
    private float time;

    void Start()
    {
        text = gameObject.GetComponent<Text>();
    }

    void Update()
    {
        // オブジェクトのAlpa値更新
        text.color = GetAlphaColor(text.color);

        if (Input.GetMouseButtonDown(0))
        {
            Destroy(gameObject);
        }
    }

    // Alpa値を更新してColorを返す
    Color GetAlphaColor(Color color)
    {
        time += Time.deltaTime * 5.0f * speed;
        color.a = Mathf.Sin(time) * 0.9f + 0.9f;

        return color;
    }

}
