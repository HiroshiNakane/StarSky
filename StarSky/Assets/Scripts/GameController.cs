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
    private GameObject parent;

    [SerializeField]
    private GameObject blackholeParent;

    [SerializeField]
    private GameObject meteoPrefab;

    [SerializeField]
    private Transform earth;

    [SerializeField]
    private Text timer;

    // MeteoHitPrefabにアタッチできないのでGameManagerでアタッチする用
    public Text meteoCount;

    // ブラックホールを出せる回数UI用カウント
    [SerializeField]
    private GameObject[] BHCounts;

    // 一度に出せるブラックホールの数
    int blackholeCount;

    private GameObject _blackHole;

    private Vector3 _centerPos = new Vector3(800 / 2, 1200 / 2, 0);

    // タイマー
    private float timeData = 0.0f;
    private bool isStart = false;

    private List<FallingMeteorites> meteos = new List<FallingMeteorites>();

    void Start()
    {
        timeData = 31.0f;
        timer.text = "30";
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
            if (rnd == 0)
            {
                AddMeteo();
            }
        }

        if (timeData == 0)
        {
            new WaitForSeconds(1.0f);
            SceneManager.LoadScene("GameClearScene");
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
            _blackHole.GetComponent<BlackholeView>().Init(BlackHoleDestroy, HitMeteo);

            // ブラックホール出したらカウント減少&その分のUI非表示
            blackholeCount--;
            DecreaseBHCounts();
        }

    }

    void BlackHoleDestroy()
    {
        // ブラックホールが消えたらカウント増加とUI表示
        blackholeCount++;
        IncreaseBHCounts();
    }

    void DecreaseBHCounts()
    {
        for(int i = 0; i <= BHCounts.Length; i++)
        {
            if (blackholeCount == i)
                BHCounts[i].SetActive(false);
        }
    }

    void IncreaseBHCounts()
    {
        for (int i = 0; i <= BHCounts.Length; i++)
        {
            if (blackholeCount > i)
                BHCounts[i].SetActive(true);
        }
    }

    private void HitMeteo(Vector3 blackHolePos, FallingMeteorites meteo)
    {
        meteo.AddMeteoPower(blackHolePos);
    }


}
