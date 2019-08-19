using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EarthHP : MonoBehaviour
{
    [SerializeField]
    private GameObject bombEffect;

    [SerializeField]
    private GameObject parent;

    public int earthHP;

    void Start()
    {
        earthHP = 25;
    }
    
    void Update()
    {
        if(earthHP == 0)
        Invoke("SceneMove", 1.0f);
    }

    void SceneMove()
    {
       SceneManager.LoadScene("GameOverScene");   
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // 当たったオブジェクトにMeteoタグがついていたら
        if (other.gameObject.CompareTag("Meteo"))
        {
            // 隕石を削除
            Destroy(other.gameObject);
            Instantiate(bombEffect, other.transform.position, Quaternion.identity);

            earthHP -= 1;

            if (earthHP < 1)
                gameObject.GetComponent<Image>().color = new Color(1.0f, 0.0f, 0.0f);

            else if (earthHP < 11)
                gameObject.GetComponent<Image>().color = new Color(1.0f, 0.3f, 0.3f);

            else if (earthHP < 21)
                gameObject.GetComponent<Image>().color = new Color(1.0f, 0.7f, 0.7f);

            Debug.Log(earthHP);
        }
    }
}
