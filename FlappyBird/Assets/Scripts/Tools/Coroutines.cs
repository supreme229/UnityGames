using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Coroutines
{
    private static bool isCoroutineExecuting = false;
    public delegate void Task();
    public static IEnumerator ExecuteAfterTime(float time, Task task)
    {
        if (isCoroutineExecuting)
        {
            yield break;
        }
        isCoroutineExecuting = true;
        yield return new WaitForSeconds(time);
        task();
        isCoroutineExecuting = false;
    }

    public static IEnumerator WaitForUnscaledSeconds(float dur)
    {
        var cur = 0f;
        while (cur < dur)
        {
            yield return null;
            cur += Time.unscaledDeltaTime;
        }
    }
}
