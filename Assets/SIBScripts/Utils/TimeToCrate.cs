using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TimeToCrate : MonoBehaviour
{
    public static float currCountdownValue = 0f;

    void Start()
    {
        StartCoroutine(StartCountdown());
    }

    public IEnumerator StartCountdown()
    {
        while (true)
        {
            TimeToCrate.currCountdownValue += 0.3f;
            yield return new WaitForSeconds(0.3f);
        }
    }
}
