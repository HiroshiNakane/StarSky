using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthHP : MonoBehaviour
{
    [SerializeField]
    private GameObject bombEffect;

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
            //Instantiate(bombEffect, other.transform.position, Quaternion.identity);

        }
    }
}
