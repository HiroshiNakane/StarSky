using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [SerializeField]
    private GameObject _blackHolePrefab = default;
    [SerializeField]
    private StarView _star = default;
    //[SerializeField]
    //private GameObject _parent;
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

        screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(mousePos);

        if (!_isBlackHoleVisible)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _isBlackHoleVisible = true;

                // z軸の位置を修正
                mousePos.z = 10.0f;

                // ブラックホールを生成
                _blackHole = Instantiate((_blackHolePrefab), Camera.main.ScreenToWorldPoint(mousePos),_blackHolePrefab.transform.rotation);

                _blackHolePrefab.transform.position = screenToWorldPointPosition;

                instantiateEffect = Instantiate(blackHoleEffect, _blackHole.transform.position, Quaternion.identity) as GameObject;

                // ブラックホールの座標を更新
                _blackHole.GetComponent<RectTransform>().localPosition = mousePos - _centerPos;

            }
        }
        else
        {
            var pos = mousePos - _centerPos;

            // ブラックホールの座標を更新
            _blackHole.GetComponent<RectTransform>().localPosition = pos;

            var direction = pos - _star.GetComponent<RectTransform>().localPosition;

            direction.Normalize();

            var magnitude = direction.magnitude;

            var pow = 0.07f / magnitude;

            if(pos.x < -400)
            {
                pow = -0.13f / magnitude;
            }

            _star.AddForce(direction, pow);

            if (Input.GetMouseButtonUp(0))
            {
                // ブラックホールを削除
                Destroy(_blackHole);

                Destroy(instantiateEffect);

                _isBlackHoleVisible = false;

            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            //var pos = mousePos - _centerPos;
            Debug.Log(mousePos.x);
        }

    }

}
