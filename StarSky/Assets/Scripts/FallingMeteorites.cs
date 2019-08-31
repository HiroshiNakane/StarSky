using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingMeteorites : MonoBehaviour
{
    Rigidbody2D meteoRigid;

    private float totalPower = 1000.0f;

    void Start()
    {
        
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BlackHole")
        {
            this.tag = "BreakingMeteo";
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BreakingMeteo")
        {
            Destroy(this.gameObject);
        }
    }


    public void Init(Vector3 earthPos)
    {
        meteoRigid = GetComponent<Rigidbody2D>();
        var moveVec = Vector3.Normalize(earthPos - transform.localPosition);
        meteoRigid.AddForce(moveVec * 100, ForceMode2D.Impulse);
    }

    public void AddMeteoPower(Vector3 blackHolePos)
    {
        var distance = Vector3.Magnitude(blackHolePos - transform.localPosition);

        var power = totalPower / distance;

        var powerVec = blackHolePos - transform.localPosition;

        powerVec.Normalize();
        GetComponent<Rigidbody2D>().AddForce(powerVec * power, ForceMode2D.Impulse);
    }

}
