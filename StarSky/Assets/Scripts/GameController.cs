using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [SerializeField]
    private GameObject _blackHolePrefab;
    [SerializeField]
    private StarView _star;
    [SerializeField]
    private GameObject _parent;

    private GameObject _blackHole;
    private Vector3 _centerPos = new Vector3(800 / 2, 1280 / 2, 0);

    private bool _isBlackHoleVisible = false;

    void Start()
    {
        
    }

    void Update()
    {

        var mousePos = Input.mousePosition;

        if (!_isBlackHoleVisible)
        {
            if (Input.GetMouseButtonDown(0))
            {
                mousePos.z = 10.0f;
                // ブラックホールを生成(Instantiate)
                Instantiate(_blackHolePrefab,Camera.main.ScreenToWorldPoint(mousePos), _blackHolePrefab.transform.rotation);
            }
        }
        else
        {
            mousePos = Input.mousePosition;

            // ブラックホールの座標を更新
            _blackHole.GetComponent<RectTransform>().localPosition = mousePos;

            var direction = mousePos - _star.GetComponent<RectTransform>().localPosition;

            if (Input.GetMouseButtonUp(0))
            {
                // ブラックホールを削除
                Destroy(_blackHolePrefab);
            }
        }
        
    }
}
