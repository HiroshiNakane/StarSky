using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float time;
    Text timerText;

    void Start()
    {
        time = 0.0f;
        timerText = GetComponent<Text>();
    }

    void Update()
    {
        time += Time.deltaTime;// 毎フレームの時間を加算
        int minute = (int)time / 60;
        int second = (int)time % 60;
        int millisecond = (int)(time * 1000 % 1000);
        string minText, secText, millisecText;
        if (minute < 10)
        {
            minText = "0" + minute.ToString();
        }
        else
        {
            minText = minute.ToString();
        }
        if (second < 10)
        {
            secText = "0" + second.ToString();
        }
        else
        {
            secText = second.ToString();
        }
        if (millisecond < 10)
        {
            millisecText = "00" + millisecond.ToString();
        }else if(millisecond < 100)
        {
            millisecText = "0" + millisecond.ToString();
        }/*else if(millisecond < 1000)
        {
            millisecText = "" + millisecond.ToString();
        }*/
        else
        {
            millisecText = millisecond.ToString();
        }

        timerText.text = minText + ":" + secText + ":" + millisecText;
 
    }
}
