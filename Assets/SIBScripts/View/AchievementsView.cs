using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class AchievementsView : MonoBehaviour
{
    public List<AchievementsSO> achievements;

    [SerializeField]
    public List<bool> achievementsShowed;

    [SerializeField]
    public Transform startPosTransform;
    [SerializeField]
    public Transform endPosTransform;


    [SerializeField]
    public TextMeshProUGUI titleText;
    [SerializeField]
    public TextMeshProUGUI descriptionText;
    [SerializeField]
    public Image achieveSprite;
    [SerializeField]
    public AudioSource audio;

    [SerializeField]
    public static AchievementsView selfView;

    void Start()
    {
        AchievementsView.selfView = this;

        Vector3 startPos = startPosTransform.position;
        Vector3 endPos = endPosTransform.position;

        this.transform.position = startPos;
        //AchievementsView.ShowAchievement(0);
    }


    public static void ShowAchievement(int index)
    {
        if (selfView.achievementsShowed[index] == true)
        {
            return;
        }

        selfView.achievementsShowed[index] = true;
        selfView.titleText.text = selfView.achievements[index].title;
        selfView.descriptionText.text = selfView.achievements[index].description;
        selfView.achieveSprite.sprite = selfView.achievements[index].sprite;

        selfView.audio.Play();
        selfView.ShowAchievementAnimation();

    }

    public void ShowAchievementAnimation()
    {
        StartCoroutine(ShowAchievementCoroutine());
    }

    public IEnumerator ShowAchievementCoroutine()
    {

        Vector3 startPos = startPosTransform.position;
        Vector3 endPos = endPosTransform.position;

        float elapsedTime = 0f;
        float animationDuration = 1f;
        float waitDuration = 2f;

        while (elapsedTime < animationDuration)
        {
            float t = elapsedTime / animationDuration;
            this.transform.position = Vector3.Lerp(startPos, endPos, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(waitDuration);
        elapsedTime = 0f;
        while (elapsedTime < animationDuration)
        {
            float t = elapsedTime / animationDuration;
            this.transform.position = Vector3.Lerp(endPos, startPos, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }


        this.transform.position = startPos;
        yield return null;
    }

    private void Setup(int index)
    {

    }
}
