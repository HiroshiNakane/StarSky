using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EarthHP : MonoBehaviour
{
    [SerializeField]
    private GameObject earthExplosion;

    [SerializeField]
    private AudioClip explosionSE;

    AudioSource audioSource;

    [SerializeField]
    private List<Transform> _earthExplosionLists = new List<Transform>();

    public int earthHP;

    void Start()
    {
        earthHP = 25;

        audioSource = GetComponent<AudioSource>();
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
            Instantiate(earthExplosion, other.transform.position, Quaternion.identity);

            audioSource.PlayOneShot(explosionSE);

            earthHP -= 1;

            if (earthHP < 1)
                gameObject.GetComponent<Image>().color = new Color(1.0f, 0.0f, 0.0f);

            else if (earthHP < 11)
                gameObject.GetComponent<Image>().color = new Color(1.0f, 0.3f, 0.3f);

            else if (earthHP < 21)
                gameObject.GetComponent<Image>().color = new Color(1.0f, 0.7f, 0.7f);

            Debug.Log(earthHP);
        }

        // 当たったオブジェクトにBreakingMeteoタグがついていたら
        if (other.gameObject.CompareTag("BreakingMeteo"))
        {
            // 隕石を削除
            Destroy(other.gameObject);
            Instantiate(earthExplosion, other.transform.position, Quaternion.identity);

            audioSource.PlayOneShot(explosionSE);

            //Destroy(earthExplosion, 1.0f);

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
