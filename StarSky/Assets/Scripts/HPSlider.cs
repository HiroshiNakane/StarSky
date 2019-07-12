using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPSlider : MonoBehaviour
{
    Slider hpSlider;

    GameObject earthHP;

    EarthHP script;

    void Start()
    {
        earthHP = GameObject.Find("EarthHit");
        script = earthHP.GetComponent<EarthHP>();

        hpSlider = GetComponent<Slider>();
        int maxHP = 25;
        int nowHP = 25;

        hpSlider.maxValue = maxHP;
        hpSlider.value = nowHP;
    }

    void Update()
    {
        int sliderHP = script.earthHP;

        hpSlider.value = sliderHP;
    }
}
