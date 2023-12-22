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
    private void Start() {
        gameObject.SetActive(false);
    }
    public void FillInfoPanelWithRequirement(Resource roomRequirement){
        foodText.text=roomRequirement.food.ToString();
        electricText.text=roomRequirement.electric.ToString();
        metalText.text=roomRequirement.metal.ToString();
        oxygenText.text=roomRequirement.oxygen.ToString();

    }
}
