using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject _blackHolePrefab;

    [SerializeField]
    private GameObject blackHoleEffect;

    [SerializeField]
    private GameObject parent;

    [SerializeField]
    private GameObject blackholeParent;

    [SerializeField]
    private GameObject meteoPrefab;

    [SerializeField]
    private Transform earth;

    [SerializeField]
    private Text timer;

    public int blackholeCount;

    //private GameObject instantiateEffect;

    private GameObject _blackHole;
    
    private Vector3 _centerPos = new Vector3(800 / 2, 1200 / 2, 0);

    // タイマー
    private float timeData = 0.0f;
    private bool isStart = false;

    private List<FallingMeteorites> meteos = new List<FallingMeteorites>();

    void Start()
    {
        timeData = 30.0f;
        timer.text = "0";
        blackholeCount = 3;
    }

    void Update()
    {
        if (timeData > 0 && isStart)
        {
            timeData -= Time.deltaTime;
            if (timeData < 0)
                timeData = 0;

            timer.text = ((int)timeData).ToString();

            if (Input.GetMouseButtonDown(0))
            {
                AddBlackHole();
            }

        }

        if (Input.GetMouseButtonDown(0) && !isStart)
        {
            isStart = true;
        }

        if (timeData > 0 && isStart)
        {
            var rnd = Random.Range(0, (int)timeData * 3);
            if(rnd == 0)
            {
                AddMeteo();
            }
        }

        if(timeData == 0)
        {
            SceneManager.LoadScene("ResultScene");
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

    void AddBlackHole()
    {
        var mousePos = Input.mousePosition;

        if (blackholeCount < 1)
        return;
        {
            // ブラックホールを生成
            _blackHole = Instantiate(_blackHolePrefab, blackholeParent.transform);
            _blackHole.transform.localPosition = Camera.main.ScreenToWorldPoint(mousePos);

            _blackHole.GetComponent<BlackholeView>().Init(BlackHoleDestroy);
            blackholeCount--;
        }

        void BlackHoleDestroy()
        {
            blackholeCount++;
        }
    }

}
