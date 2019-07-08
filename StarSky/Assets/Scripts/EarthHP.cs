using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EarthHP : MonoBehaviour
{
    [SerializeField]
    private GameObject bombEffect;

    int earthHP;

    void Start()
    {
        earthHP = 30;
    }
    
    void Update()
    {
        if(earthHP == 0)
        {
            SceneManager.LoadScene("ResultScene");
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // 当たったオブジェクトにMeteoタグがついていたら
        if (other.gameObject.CompareTag("Meteo"))
        {
            // 隕石を削除
            Destroy(other.gameObject);
            //Instantiate(bombEffect, other.transform.position, Quaternion.identity);

            earthHP -= 1;

            //gameObject.GetComponent<Image>().color = new Color(255.0f, 0.0f, 0.0f);

            
        }
    }
}
