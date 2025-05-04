using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;


public class DeviceView : MonoBehaviour
{
    public DeviceSO deviceSO;

    [SerializeField]
    private TextMeshProUGUI cheatNameText;
    [SerializeField]
    private TextMeshProUGUI descriptionText;

    [SerializeField]
    private TextMeshProUGUI[] calcChars;

    [SerializeField]
    private PlayerView playerView;

    public int integerPart;
    public int decimalPart;

    void Start()
    {
        Setup();
    }

    private void Setup()
    {
        cheatNameText.text = deviceSO.cheatName;
        descriptionText.text = deviceSO.description;
        IntToCalcVals(deviceSO.initialVal);
    }

    public void IntToCalcVals(int value)
    {
        if ((value < 0)||(value > 9999))
        {
            return;
        }
        for (int i = 0; i < calcChars.Length; i++)
        {
            Debug.Log($"{value % 10}");
            calcChars[i].text = (value % 10).ToString();

            value = value / 10;
        }
    }

    public void ClearVals()
    {
        for (int i = 0; i < calcChars.Length; i++)
        {
            calcChars[i].text = "0";
        }
        CharsToVal();
    }

    public void AddChar(string charVal)
    {
        for (int i = calcChars.Length - 2; i >= 0; i--)
        {
            calcChars[i + 1].text = calcChars[i].text;
        }
        calcChars[0].text = charVal;
        CharsToVal();
    }

    public void CharsToVal()
    {
        integerPart = 0;
        decimalPart = 0;

        bool isIntegerPart = true;

        for (int i = calcChars.Length - 1; i >= 0; i--)
        {
            if (calcChars[i].text == ".")
            {
                isIntegerPart = false;
                continue;
            }

            if (isIntegerPart)
            {
                integerPart *= 10;
                integerPart += int.Parse(calcChars[i].text);
            }
            else
            {
                decimalPart *= 10;
                decimalPart += int.Parse(calcChars[i].text);
            }
        }
        Debug.Log($"{integerPart}.{decimalPart}");
    }

    public void SetPlayerViewVals()
    {
        playerView.integerPart = integerPart;
        playerView.decimalPart = decimalPart;
        playerView.UpdateCountText();
    }
}
