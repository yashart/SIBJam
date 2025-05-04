using UnityEngine;

public class HackDeviceSwitch : MonoBehaviour
{
    [SerializeField]
    private bool isDeviceActive;
    [SerializeField]
    private GameObject deviceGameObject;
    
    public void ToggleDevice()
    {
        deviceGameObject.SetActive(!isDeviceActive);
        isDeviceActive = !isDeviceActive;
    }
}
