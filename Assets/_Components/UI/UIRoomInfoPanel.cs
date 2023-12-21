using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIRoomInfoPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text foodText;
    [SerializeField] private TMP_Text electricText;
    [SerializeField] private TMP_Text metalText;
    [SerializeField] private TMP_Text oxygenText;
    public void FillInfoPanelWithRequirement(RoomRequirement roomRequirement){
        foodText.text=roomRequirement.food.ToString();
        electricText.text=roomRequirement.electric.ToString();
        metalText.text=roomRequirement.metal.ToString();
        oxygenText.text=roomRequirement.oxygen.ToString();

    }
}