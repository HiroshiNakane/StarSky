using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingMeteorites : MonoBehaviour
{

    Rigidbody2D meteoRigid;

    private float totalPower = 100.0f;

    private Vector3 blackHole;

    void Start()
    {
        
    }

    void Update()
    {


    }

    public void Init(Vector3 earthPos)
    {
        meteoRigid = GetComponent<Rigidbody2D>();
        var moveVec = Vector3.Normalize(earthPos - transform.localPosition);
        meteoRigid.AddForce(moveVec * 100, ForceMode2D.Impulse);
    }

    public void AddMeteoPower(Vector3 blackHolePos)
    {
        var distance = Vector3.Magnitude(blackHole - transform.localPosition);

        var power = totalPower / distance;

        var powerVec = blackHole - transform.localPosition;

        powerVec.Normalize();
        GetComponent<Rigidbody2D>().AddForce(powerVec * power, ForceMode2D.Impulse);
    }

}
