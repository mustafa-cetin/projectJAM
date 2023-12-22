using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIInfoPanel : MonoBehaviour
{
    [SerializeField]
    private TMP_Text infoText;
    [SerializeField]
    private TMP_Text timeText;
    [SerializeField]
    private TMP_Text dayText;
    void Update()
    {
        timeText.text=Shelter.Instance.timeText;
        dayText.text=Shelter.Instance.Day.ToString();
        infoText.text=Shelter.Instance.currentModeNew.ToString();


    }
}
