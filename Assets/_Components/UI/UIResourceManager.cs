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

    public TMP_Text notifyText;

    public Slider rebelSlider;
    private void Update() {
        foodText.text=Shelter.Instance.food.ToString();
        electricText.text=Shelter.Instance.electric.ToString();
        metalText.text=Shelter.Instance.metal.ToString();
        oxygenText.text=Shelter.Instance.oxygen.ToString();
        rebelSlider.value=Shelter.Instance.rebel;
    }
    public void NotifyElectric(int value){
        TMP_Text cloneNotify=Instantiate(notifyText,transform);
        cloneNotify.text=value.ToString();
        Vector3 position=electricText.transform.position;
        position.y-=2f;
        cloneNotify.transform.position=position;
    }
    public void NotifyFood(int value){
        TMP_Text cloneNotify=Instantiate(notifyText,transform);
        cloneNotify.text=value.ToString();
        Vector3 position=foodText.transform.position;
        position.y-=2f;
        cloneNotify.transform.position=position;
    }
    public void NotifyOxygen(int value){
        
        TMP_Text cloneNotify=Instantiate(notifyText,transform);
        cloneNotify.text=value.ToString();
        Vector3 position=oxygenText.transform.position;
        position.y-=2f;
        cloneNotify.transform.position=position;
    }
    public void NotifyMetal(int value){
        
        TMP_Text cloneNotify=Instantiate(notifyText,transform);
        cloneNotify.text=value.ToString();
        Vector3 position=metalText.transform.position;
        position.y-=2f;
        cloneNotify.transform.position=position;
    }
}
