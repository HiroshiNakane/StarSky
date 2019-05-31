using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitial : MonoBehaviour
{

    [RuntimeInitializeOnLoadMethod]
    static void OnRuntimeMethodLoad()
    {
        Screen.SetResolution(800, 1200, true, 60);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
