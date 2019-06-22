using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    [SerializeField]
    private GameObject _blackHolePrefab;

    [SerializeField]
    private GameObject blackHoleEffect;

    [SerializeField]
    private GameObject parent;

    [SerializeField]
    private GameObject meteoPrefab;

    [SerializeField]
    private Transform earth;

    [SerializeField]
    private Text timer;

    private GameObject instantiateEffect;

    private GameObject _blackHole;
    
    private Vector3 _centerPos = new Vector3(800 / 2, 1280 / 2, 0);

    Vector3 screenToWorldPointPosition;

    private bool _isBlackHoleVisible = false;

    // タイマー
    private float timeData = 0.0f;
    private bool isStart = false;

    private List<FallingMeteorites> meteos = new List<FallingMeteorites>();

    void Start()
    {
        timeData = 30.0f;
        timer.text = "0";
    }

    void Update()
    {
        if (timeData > 0 && isStart)
        {
            timeData -= Time.deltaTime;
            if (timeData < 0)
                timeData = 0;

            timer.text = ((int)timeData).ToString();

        }
        if(timeData > 0 && isStart)
        {
            var rnd = Random.Range(0, (int)timeData * 3);
            if(rnd == 0)
            {
                AddMeteo();
            }
        }

        if(Input.GetMouseButtonDown(0) && !isStart)
        {
            isStart = true;
        }
    }

    void AddMeteo()
    {
        var meteo = Instantiate(meteoPrefab, parent.transform);
        meteo.transform.localPosition = new Vector2(Random.Range(-380.0f, 380.0f), 740.0f);
        var meteoView = meteo.GetComponent<FallingMeteorites>();
        meteoView.Init(earth.localPosition);
        meteos.Add(meteoView);
    }
}
