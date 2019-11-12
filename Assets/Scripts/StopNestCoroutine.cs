using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopNestCoroutine : MonoBehaviour
{
    void Start()
    {
        var iter = _CoroutineA();
        StartCoroutine(iter);
        Log.I("Start", "开始协程");
        StopCoroutine(iter);
    }
        
    IEnumerator _CoroutineA()
    {
        var log = Log.Get("协程A");
        log.I("第一个代码段");

        // ....

        // 如果调用StopCoroutine()_CoroutineA的实例
        // 这里并没有停止掉_NestCoroutine(1);
        yield return StartCoroutine(_NestCoroutine(1)); 

        // ....
        
        log.I("第1个_NestCoroutine之后");

        // ....

        yield return _NestCoroutine(2);

        // ....

        log.I("第2个_NestCoroutine之后");

        // 为了测试
        yield return new WaitForEndOfFrame();
        this.enabled = false;
    }

    IEnumerator _NestCoroutine(int i)
    {
        var log = Log.Get("嵌套协程序");
        log.I("第一个代码段 {0}", i);

        yield return _NestCoroutineBreak("1");
        log.I("等待 _NestCoroutineBreak 之后 1 {0}", i);

        yield return null;
        log.I("等待 null 之后 {0}", i);

        yield return _NestCoroutineBreak("2");
        log.I("等待 _NestCoroutineBreak 之后 2 {0}", i);

        yield return _NestCoroutineBreak("3");
        log.I("等待 _NestCoroutineBreak 之后 3 {0}", i);
    }

    IEnumerator _NestCoroutineBreak(string breakTag)
    {
        var log = Log.Get("嵌套Break协程序");
        log.I("第一个代码段 {0}", breakTag);
        yield break;
        log.I("break之后的 {0}", breakTag);
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
