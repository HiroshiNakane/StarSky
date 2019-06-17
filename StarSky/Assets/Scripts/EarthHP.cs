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

    void OnCollisionEnter(Collision other)
    {
        // 当たったオブジェクトにMeteoriteタグがついていたら
        if (other.gameObject.CompareTag("Meteorite"))
        {
            // 隕石を削除
            Destroy(other.gameObject);
        }
    }
}
