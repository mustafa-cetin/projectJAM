using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIResourceManager : MonoBehaviour
{
    public TMP_Text foodText;
    public TMP_Text electricText;
    public TMP_Text metalText;
    public TMP_Text oxygenText;

    public Slider rebelSlider;
    private void Update() {
        foodText.text=Shelter.Instance.food.ToString();
        electricText.text=Shelter.Instance.electric.ToString();
        metalText.text=Shelter.Instance.metal.ToString();
        oxygenText.text=Shelter.Instance.oxygen.ToString();
        rebelSlider.value=Shelter.Instance.rebel;
    }
}
