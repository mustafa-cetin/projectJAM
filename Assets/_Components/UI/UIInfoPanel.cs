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
        switch (Shelter.Instance.currentMode)
        {
            case Mode.None:
                infoText.text="None";
                break;
            case Mode.Build:
                infoText.text="Build Mode";
                break;
            case Mode.Character:
                infoText.text="Character Movement Mode";
                break;
            case Mode.RoomEdit:
                infoText.text="Room Edit Mode";
                break;
        }

    }
}
