using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "VisualNovellSO", menuName = "Scriptable Objects/VisualNovellSO")]
public class VisualNovellSO : ScriptableObject
{
    public string characterName;
    public string text;
    public string textComment;
    public Sprite leftSprite;
    public Sprite rightSprite;
    public GameObject nextScene;
}
