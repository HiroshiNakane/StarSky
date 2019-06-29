using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingMeteorites : MonoBehaviour
{

    Rigidbody2D meteoRigid;

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
}
