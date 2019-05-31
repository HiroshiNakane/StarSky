using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform player;

    private Vector3 offset;

    void Start()
    {
        offset = GetComponent<Transform>().position - player.position;
    }

    void Update()
    {
        GetComponent<Transform>().position = player.position + offset; 
    }

    /*void LateUpdate()
    {
        transform.position = player.transform.position + offset;    
    }*/
}
