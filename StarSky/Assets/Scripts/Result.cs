﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {

    }

    public void OnclickReturnTitle()
    {
        SceneManager.LoadScene("Title");
    }

    public void OnclickRetry()
    {
        SceneManager.LoadScene("MainScene");
    }
}