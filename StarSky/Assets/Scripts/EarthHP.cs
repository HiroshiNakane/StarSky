using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthHP : MonoBehaviour
{
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // 当たったオブジェクトにMeteoタグがついていたら
        if (other.gameObject.CompareTag("Meteo"))
        {
            // 隕石を削除
            Destroy(other.gameObject);
        }
    }
}
