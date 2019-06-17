using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [SerializeField]
    private GameObject _blackHolePrefab;

    [SerializeField]
    private GameObject blackHoleEffect;

    private GameObject instantiateEffect;

    private GameObject _blackHole;
    
    private Vector3 _centerPos = new Vector3(800 / 2, 1280 / 2, 0);

    Vector3 screenToWorldPointPosition;

    private bool _isBlackHoleVisible = false;

    void Start()
    {
        
    }

    void Update()
    {
        var mousePos = Input.mousePosition;

        mousePos.z = 10.0f;

        screenToWorldPointPosition = Camera.main.WorldToScreenPoint(_blackHolePrefab.transform.position);

        //_blackHole = Instantiate((_blackHolePrefab), Camera.main.ScreenToWorldPoint(mousePos), _blackHolePrefab.transform.rotation);

        //instantiateEffect = Instantiate(blackHoleEffect, _blackHole.transform.position, Quaternion.identity) as GameObject;

        if (!_isBlackHoleVisible)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _isBlackHoleVisible = true;

                // ブラックホールを生成
                _blackHole = Instantiate((_blackHolePrefab), Camera.main.ScreenToWorldPoint(mousePos),_blackHolePrefab.transform.rotation);

                instantiateEffect = Instantiate(blackHoleEffect, _blackHole.transform.position, Quaternion.identity) as GameObject;

                // 生成してから２秒後に消す
                Destroy(_blackHole, 2.0f);

                Destroy(instantiateEffect, 2.0f);
            }
        }
        else
        {
            //var pos = mousePos - _centerPos;

            //var direction = pos - _star.GetComponent<RectTransform>().localPosition;

            //direction.Normalize();

            //var magnitude = direction.magnitude;

            //var pow = 0.07f / magnitude;

            //if(pos.x < -400)
            //{
            //    pow = -0.13f / magnitude;
            //}

            //_star.AddForce(direction, pow);

            if (Input.GetMouseButtonUp(0))
            {
                _isBlackHoleVisible = false;

            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(mousePos.x);
        }

    }

}
