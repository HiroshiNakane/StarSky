using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMeteorites : MonoBehaviour
{
    public GameObject meteorite;

    float generateTime; // 隕石生成時間

    void Start()
    {
        generateTime = 1.0f; // 最初の隕石降下時間
    }

    void Update()
    {
        generateTime -= Time.deltaTime;
        if (generateTime <= 0.0f)
        {
            generateTime = 1.5f; // 1.5秒毎に降らせる

            // 隕石出現座標
            float x = Random.Range(-2.8f, 2.8f);
            float y = Random.Range(3.5f, 5.5f);
            float z = 0.0f;

            // 隕石生成
            Instantiate(meteorite, new Vector3(x, y, z), Quaternion.identity);
        }

    }
}
