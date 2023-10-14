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

    public List<TMP_Text> electricNotifyTexts;
        public List<TMP_Text> foodNotifyTexts;
            public List<TMP_Text> oxygenNotifyTexts;
                public List<TMP_Text> metalNotifyTexts;

    public Slider rebelSlider;
    private void Update() {
        foodText.text=Shelter.Instance.Food.ToString();
        electricText.text=Shelter.Instance.Electric.ToString();
        metalText.text=Shelter.Instance.Metal.ToString();
        oxygenText.text=Shelter.Instance.Oxygen.ToString();
        rebelSlider.value=Shelter.Instance.rebel;
    }
    public void NotifyElectric(int value){
        foreach (var item in electricNotifyTexts)
        {
            if (item==null)
            {
                electricNotifyTexts.Remove(item);
            }
        }
        TMP_Text cloneNotify=Instantiate(notifyText,transform);
        electricNotifyTexts.Add(cloneNotify);
        cloneNotify.text=value.ToString();
        Vector3 position=electricText.transform.position;
        position.y-=15f*electricNotifyTexts.Count;
        cloneNotify.transform.position=position;
    }
    public void NotifyFood(int value){
        foreach (var item in foodNotifyTexts)
        {
            if (item==null)
            {
                foodNotifyTexts.Remove(item);
            }
        }
        TMP_Text cloneNotify=Instantiate(notifyText,transform);
        foodNotifyTexts.Add(cloneNotify);
        cloneNotify.text=value.ToString();
        Vector3 position=foodText.transform.position;
        position.y-=15f*foodNotifyTexts.Count;
        cloneNotify.transform.position=position;
    }
    public void NotifyOxygen(int value){
        
        foreach (var item in oxygenNotifyTexts)
        {
            if (item==null)
            {
                oxygenNotifyTexts.Remove(item);
            }
        }
        TMP_Text cloneNotify=Instantiate(notifyText,transform);
        oxygenNotifyTexts.Add(cloneNotify);
        cloneNotify.text=value.ToString();
        Vector3 position=oxygenText.transform.position;
        position.y-=15f*oxygenNotifyTexts.Count;
        cloneNotify.transform.position=position;
    }
    public void NotifyMetal(int value){
        
        foreach (var item in metalNotifyTexts)
        {
            if (item==null)
            {
                metalNotifyTexts.Remove(item);
            }
        }
        TMP_Text cloneNotify=Instantiate(notifyText,transform);
        metalNotifyTexts.Add(cloneNotify);
        cloneNotify.text=value.ToString();
        Vector3 position=metalText.transform.position;
        position.y-=15f*metalNotifyTexts.Count;
        cloneNotify.transform.position=position;
    }
}
