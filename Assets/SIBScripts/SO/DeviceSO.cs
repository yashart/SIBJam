using UnityEngine;

[CreateAssetMenu(fileName = "DeviceSO", menuName = "Scriptable Objects/DeviceSO")]
public class DeviceSO : ScriptableObject
{
    public string cheatName;
    public string description;
    public int initialVal;
    public string solveVal;
}
