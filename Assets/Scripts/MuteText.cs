using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MuteText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UpdatetheText()
    {
        if (SalesmanController.instance.mute)
        {
            GetComponent<TextMeshProUGUI>().text = "UNMUTE";
        }
        if (!SalesmanController.instance.mute)
        {
            GetComponent<TextMeshProUGUI>().text = "MUTE";
        }
    }
}
