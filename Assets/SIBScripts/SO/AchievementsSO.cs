using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "AchievementsSO", menuName = "Scriptable Objects/AchievementsSO")]
public class AchievementsSO : ScriptableObject
{
    public string title;
    public string description;
    public Sprite sprite;
}
