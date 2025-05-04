using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class AchieveTimer : MonoBehaviour
{
    float currCountdownValue;

    void Start()
    {
        StartCoroutine(StartCountdown(15f));
    }

    public IEnumerator StartCountdown(float countdownValue = 10)
    {
        currCountdownValue = countdownValue;
        while (currCountdownValue > 0)
        {
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
        }
        AchievementsView.ShowAchievement(5);
    }
}
