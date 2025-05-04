using UnityEngine;

public class StartAchievement : MonoBehaviour
{
    public int achieveIndex;

    void Start()
    {
        ShowAchievement(achieveIndex);
    }
    public void ShowAchievement(int index)
    {
        AchievementsView.ShowAchievement(index);
    }
}
