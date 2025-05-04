using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class DeviceAnimation : MonoBehaviour
{
    [SerializeField]
    private Transform hideTransformGameObject;
    [SerializeField]
    private Transform visibleTransformGameObject;
    [SerializeField]
    private bool isAnimationLock;
    [SerializeField]
    private float animationDuration;

    [SerializeField]
    private bool isDeviceVisible;

    [SerializeField]
    private bool isToggle;

    [SerializeField]
    private bool isCancelUpdate;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (isToggle)
            {
                ToggleDevice();
            }else
            {
                if (!isCancelUpdate)
                {
                    ShowDevice();
                    isCancelUpdate = true;
                }
            }
        }
    }

    public void HideDevice()
    {
        if (isAnimationLock)
        {
            return;
        }
        isCancelUpdate = false;
        isAnimationLock = true;
        StartCoroutine(HideDeviceCoroutine());
    }


    private IEnumerator HideDeviceCoroutine()
    {
        float elapsedTime = 0f;

        Vector3 startPos = visibleTransformGameObject.position;
        Vector3 endPos = hideTransformGameObject.position;

        this.transform.position = startPos;

        while (elapsedTime < animationDuration)
        {
            float t = elapsedTime / animationDuration;
            this.transform.position = Vector3.Lerp(startPos, endPos, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        isDeviceVisible = false;
        isAnimationLock = false;
        yield return null;
    }

    public void ShowDevice()
    {
        if (isAnimationLock)
        {
            return;
        }
        isAnimationLock = true;
        StartCoroutine(ShowDeviceCoroutine());
    }


    private IEnumerator ShowDeviceCoroutine()
    {
        float elapsedTime = 0f;

        Vector3 startPos = hideTransformGameObject.position;
        Vector3 endPos = visibleTransformGameObject.position;

        this.transform.position = startPos;

        while (elapsedTime < animationDuration)
        {
            float t = elapsedTime / animationDuration;
            this.transform.position = Vector3.Lerp(startPos, endPos, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        isDeviceVisible = true;
        isAnimationLock = false;
        yield return null;
    }

    public void ToggleDevice()
    {
        if (isDeviceVisible)
        {
            HideDevice();
        }else
        {
            ShowDevice();
        }
    }
}
