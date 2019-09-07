using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackholeView : MonoBehaviour
{
    private System.Action _callback;
    private System.Action<Vector3, FallingMeteorites> _callbackMeteo;

    [SerializeField]
    private List<Transform> _blackHoleLists = new List<Transform>();

    private float _scale = 20.0f;

    void Start()
    {
        SetScale(_scale);    
    }

    public void Init(System.Action callback, System.Action<Vector3, FallingMeteorites> callbackMeteo)
    {
        _callback = callback;
        _callbackMeteo = callbackMeteo;

        StartCoroutine(BlackholeMakeSmaller(gameObject));
    }

    // エフェクトの大きさ変化用
    private void SetScale(float scale)
    {
        _scale = scale;
        _blackHoleLists.ForEach(x => x.localScale = new Vector3(_scale, _scale, _scale));
    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.gameObject.tag == "Meteo")
        {
            if (_callbackMeteo != null)
                _callbackMeteo(transform.GetComponent<RectTransform>().localPosition, obj.GetComponent<FallingMeteorites>());
        }

        if(obj.gameObject.tag == "BreakingMeteo")
        {
            if (_callbackMeteo != null)
                _callbackMeteo(transform.GetComponent<RectTransform>().localPosition, obj.GetComponent<FallingMeteorites>());
        }
    }

    private void OnTriggerStay2D(Collider2D obj)
    {
        if(obj.gameObject.tag == "Meteo")
        {
            if (_callbackMeteo != null)
                _callbackMeteo(transform.GetComponent<RectTransform>().localPosition, obj.GetComponent<FallingMeteorites>());
        }

        if (obj.gameObject.tag == "BreakingMeteo")
        {
            if (_callbackMeteo != null)
                _callbackMeteo(transform.GetComponent<RectTransform>().localPosition, obj.GetComponent<FallingMeteorites>());
        }
    }


    IEnumerator BlackholeMakeSmaller(GameObject target)
    {
        yield return new WaitForSeconds(1.0f);

        // 繰り返し回数
        int loopCount = 10;

        // 更新感覚
        float waitsecond = 0.05f;

        // スケール設定
        // オフセット値
        float offsetScale = -1.3f / loopCount;
        // 更新値
        float updateScale = 1.3f;

        for(int loop = 0; loop < loopCount; loop++)
        {
            // スケール更新
            updateScale = updateScale + offsetScale;
            target.transform.localScale = new Vector2(updateScale, updateScale);
            yield return new WaitForSeconds(waitsecond);
        }

        // スケールが0.01より小さくなったらオブジェクトを消す
        if (updateScale < 0.01f)
        {
           if(_callback != null)
            {
                _callback();   
            }
           Destroy(gameObject);
        }
    }

}