using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIResourceManager : MonoBehaviour
{   
    public float interval=20f;
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
    private void Start() {
        electricNotifyTexts=new List<TMP_Text>();
        foodNotifyTexts=new List<TMP_Text>();
        oxygenNotifyTexts=new List<TMP_Text>();
        metalNotifyTexts=new List<TMP_Text>();
    }
    private void Update() {
        foodText.text=Shelter.Instance.Food.ToString();
        electricText.text=Shelter.Instance.Electric.ToString();
        metalText.text=Shelter.Instance.Metal.ToString();
        oxygenText.text=Shelter.Instance.Oxygen.ToString();
        rebelSlider.value=Shelter.Instance.rebel;

    }
    public void NotifyElectric(int value){electricNotifyTexts.RemoveAll(s => s == null);
        TMP_Text cloneNotify=Instantiate(notifyText,transform);
        electricNotifyTexts.Add(cloneNotify);
        cloneNotify.text=value.ToString();
        Vector3 position=electricText.transform.position;
        position.y-=interval*electricNotifyTexts.Count;
        cloneNotify.transform.position=position;
    }
    public void NotifyFood(int value){foodNotifyTexts.RemoveAll(s => s == null);
        TMP_Text cloneNotify=Instantiate(notifyText,transform);
        foodNotifyTexts.Add(cloneNotify);
        cloneNotify.text=value.ToString();
        Vector3 position=foodText.transform.position;
        position.y-=interval*foodNotifyTexts.Count;
        cloneNotify.transform.position=position;
    }
    public void NotifyOxygen(int value){
        oxygenNotifyTexts.RemoveAll(s => s == null);
        TMP_Text cloneNotify=Instantiate(notifyText,transform);
        oxygenNotifyTexts.Add(cloneNotify);
        cloneNotify.text=value.ToString();
        Vector3 position=oxygenText.transform.position;
        position.y-=interval*oxygenNotifyTexts.Count;
        cloneNotify.transform.position=position;
    }
    public void NotifyMetal(int value){
        metalNotifyTexts.RemoveAll(s => s == null);
        TMP_Text cloneNotify=Instantiate(notifyText,transform);
        metalNotifyTexts.Add(cloneNotify);
        cloneNotify.text=value.ToString();
        Vector3 position=metalText.transform.position;
        position.y-=interval*metalNotifyTexts.Count;
        cloneNotify.transform.position=position;
    }
}
