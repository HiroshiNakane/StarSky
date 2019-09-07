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

    private float _scale = 30.0f;

    public int earthHP;

    void Start()
    {
        earthHP = 25;

        SetScale(_scale);

        audioSource = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        if(earthHP == 0)
        Invoke("SceneMove", 1.0f);
    }

    private void SetScale(float scale)
    {
        _scale = scale;
        _earthExplosionLists.ForEach(x => x.localScale = new Vector3(_scale, _scale, _scale));
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
