using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackholeView : MonoBehaviour
{

    System.Action _callBack;

    GameController Count;

    void Start()
    {
        StartCoroutine(BlackholeMakeSmaller(gameObject));

        Count = GetComponent<GameController>();
    }

    void Update()
    {
        
    }

    IEnumerator BlackholeMakeSmaller(GameObject target)
    {
        yield return new WaitForSeconds(1.0f);

        // 繰り返し回数
        int loopCount = 30;

        // 更新感覚
        float waitsecond = 0.09f;

        // スケール設定
        // オフセット値
        float offsetScale = -1.0f / loopCount;
        // 更新値
        float updateScale = 1;

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
           Destroy(gameObject);
        }
    }

    public void Init(System.Action callBack)
    {
        _callBack = callBack;

        Count.blackholeCount++;

        StartCoroutine(BlackholeMakeSmaller(gameObject));
    }

}