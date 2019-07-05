using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackholeView : MonoBehaviour
{
    System.Action _callBack;

    [SerializeField]
    private FallingMeteorites _meteo;

    void Start()
    {

    }

    public void Init(System.Action callBack)
    {
        _callBack = callBack;

        StartCoroutine(BlackholeMakeSmaller(gameObject));
    }

    IEnumerator BlackholeMakeSmaller(GameObject target)
    {
        yield return new WaitForSeconds(1.0f);

        // 繰り返し回数
        int loopCount = 40;

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
           if(_callBack != null)
            {
                _callBack();   
            }
           Destroy(gameObject);
        }
    }

}