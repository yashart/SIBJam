using UnityEngine;
using System.Collections;


public class FireAnimation : MonoBehaviour
{
    [SerializeField]
    GameObject fireObject;
    
    public void ShowFire()
    {
        AchievementsView.ShowAchievement(3);
        StartCoroutine(ShowFireCoroutine());
    }

    IEnumerator ShowFireCoroutine()
    {
        fireObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        fireObject.SetActive(false);
        yield return null;
    }
}
