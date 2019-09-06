using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FallingMeteorites : MonoBehaviour
{
    Rigidbody2D meteoRigid;

    private float totalPower = 1000.0f;

    GameObject gameManager;

    GameController script;

    public Text brokeMeteo;

    // 壊した隕石のカウント
    int BrokeMeteoCount;

    void Start()
    {
        BrokeMeteoCount = 0;

        gameManager = GameObject.Find("GameManager");
        script = gameManager.GetComponent<GameController>();

        brokeMeteo = script.meteoCount;
    }

    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BlackHole")
        {
            this.tag = "BreakingMeteo";
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {   // ブラックホールに触れた隕石で触れてない隕石を壊せるように
        if (collision.gameObject.tag == "BreakingMeteo")
        {
            Destroy(this.gameObject);
            BrokeMeteoCount += 1;
            Debug.Log(BrokeMeteoCount);
            brokeMeteo.text = ((int)BrokeMeteoCount).ToString();
        }
    }


    public void Init(Vector3 earthPos)
    {
        meteoRigid = GetComponent<Rigidbody2D>();

        // 地球のx座標の中心に落ちるように
        var moveVec = Vector3.Normalize(earthPos - transform.localPosition);
        meteoRigid.AddForce(moveVec * 100, ForceMode2D.Impulse);
    }

    // ブラックホールに触れたら移動させる
    public void AddMeteoPower(Vector3 blackHolePos)
    {
        var distance = Vector3.Magnitude(blackHolePos - transform.localPosition);

        var power = totalPower / distance;

        var powerVec = blackHolePos - transform.localPosition;

        powerVec.Normalize();
        GetComponent<Rigidbody2D>().AddForce(powerVec * power, ForceMode2D.Impulse);
    }

}
