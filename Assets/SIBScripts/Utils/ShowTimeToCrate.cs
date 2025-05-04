using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class ShowTimeToCrate : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;

    void Start()
    {
        text.text = "Time to crate: " + TimeToCrate.currCountdownValue.ToString() + " sec";
    }
    

}
