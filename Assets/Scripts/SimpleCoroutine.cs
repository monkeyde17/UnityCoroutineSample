using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCoroutine : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(_CoroutineA());
        Log.I("Start", "开始协程");
    }

    IEnumerator _CoroutineA()
    {
        var log = Log.Get("协程A");
        log.I("第一个代码段");

        yield return null;
        log.I("等待 null 之后");

        yield return new WaitForFixedUpdate();
        log.I("等待 WaitForFixedUpdate 之后");

        yield return new WaitForSeconds(0.0f);
        log.I("等待 WaitForSeconds(0.0f) 之后");

        yield return new WaitForEndOfFrame();
        log.I("等待 WaitForEndOfFrame 之后");

        // 为了测试
        yield return new WaitForEndOfFrame();
        this.enabled = false;
    }

    void Update()
    {
        Log.I("Update", "");
    }

    void LateUpdate()
    {
        Log.I("LateUpdate", "");
    }

    void FixedUpdate()
    {
        Log.I("FixedUpdate", "");
    }
    
}
