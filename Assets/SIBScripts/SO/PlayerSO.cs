using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "PlayerSO", menuName = "Scriptable Objects/PlayerSO")]
public class PlayerSO : ScriptableObject
{
    public Sprite activeSprite;
    public Sprite normalSprite;
    public Sprite withAppleSprite;

}
