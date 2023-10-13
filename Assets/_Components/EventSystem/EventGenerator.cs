using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class EventGenerator : MonoBehaviour
{

    public Events[] EventsArray;

    public TMP_Text mainText;

    public TMP_Text button1Text;

    public TMP_Text button2Text;

    public void callRandomEvent(){
        int randomEventNum = Random.Range(0,7);

        Events currentEvents = EventsArray[randomEventNum];

        mainText.text = currentEvents.Event;

        button1Text.text = currentEvents.EventChoices[0];

        button2Text.text = currentEvents.EventChoices[1];

        
    }

    public void madeEventAffects(){
        
    }

    void Start(){
        callRandomEvent();
    }
    
    




}
