using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class EventGenerator : MonoBehaviour
{
    public Vector2 positionOfImage;

    public Image eventBackground;

    public Events[] EventsArray;

    public TMP_Text mainText;

    public TMP_Text button1Text;

    public TMP_Text button2Text;

    public int choiceMade;
    public void callRandomEvent(int randomEventNum){

        Events currentEvents = EventsArray[randomEventNum];

        Sprite currentSprite = EventsArray[randomEventNum].Background;
        
        eventBackground.sprite = currentSprite;

        mainText.text = currentEvents.Event;

        button1Text.text = currentEvents.EventChoices[0];

        button2Text.text = currentEvents.EventChoices[1];

        
    }
    string checkShelterStateLevels(){
        if(Shelter.Instance.electric < 30){
            return "Electric";
        }
        if(Shelter.Instance.food < 30){
            return "Food";
        }
        if(Shelter.Instance.oxygen < 30){
            return "Oxygen";
        }
        else{ return null;}
    }

    void increaseRebel(int number){
        Shelter.Instance.rebel += number;
    }

    void decreaseRebel(int number){
        Shelter.Instance.rebel -= number;
    }
    void increaseFood(int number){
        Shelter.Instance.food += number;
    }

    void decreaseFood(int number){
        Shelter.Instance.food -= number;
    }
    void increaseOxygen(int number){
        Shelter.Instance.oxygen += number;
    }

    void decreaseOxygen(int number){
        Shelter.Instance.oxygen -= number;
    }
    void increaseElec(int number){
        Shelter.Instance.electric += number;
    }

    void decreaseElec(int number){
        Shelter.Instance.electric -= number;
    }
    void increaseMetal(int number){
        Shelter.Instance.metal += number;
    }

    void decreaseMetal(int number){
        Shelter.Instance.metal -= number;
    }

    int chance50(){
        int result = Random.Range(0, 2); // 0 veya 1 rastgele bir sayı üretir.
        return result;
    }

    void calcExpenses(){
        //people count

        //room count


    }

    public GameObject Choice1;
    public GameObject Choice2;

    public GameObject Canvas;

    public void Chosed1(){
        choiceMade = 1;
        
        Canvas.SetActive(false);
    }

    public void Chosed2(){
        choiceMade = 2; 

        Canvas.SetActive(false);
    }
    
    
    public void madeEventAffects(int eventNum){
        int prob = chance50();

        switch (eventNum)
        {
            case 0:
                Debug.Log("Resources out of" + checkShelterStateLevels());
                if(choiceMade == 0){
                    //rastgele adam seç gönder
                }
                else if(choiceMade == 1){

                }
                

                break;
            case 1:
                Debug.Log("New peoples arrived");
                if(choiceMade == 0){
                    Debug.Log("yemek ve metal arttı");
                    increaseFood(30);
                    increaseMetal(40);

                    prob = chance50();

                    if(prob == 1){
                        increaseRebel(40);
                        Debug.Log("mutluluk arttı");

                    }
                    else if(prob == 0){
                        decreaseRebel(40);
                        Debug.Log("mutluluk azaldı");

                    }
                }
                
                break;
            case 2:
            
                Debug.Log("Rebel var");
                
                if(choiceMade == 0){
                    Debug.Log("choiceMade yapıldı");
                    decreaseRebel(Shelter.Instance.rebel/2);
                    decreaseMetal(30);
                    decreaseFood(30);
                    
                }
                if(choiceMade == 1){
                    prob = chance50();
                    
                    if(prob == 1){
                        decreaseRebel(Shelter.Instance.rebel);
                        Debug.Log("rebel sıfırlandı");

                    }
                    else if(prob == 0){
                        increaseRebel(40);
                        Debug.Log("rebel arttı");

                    }
                }

                


                break;
            case 3:
                Debug.Log("Event 3 is executed");

                // drain boşalt reebel
                if(choiceMade == 1){
                                    Debug.Log("metal azaldı rebel");

                    decreaseMetal(30);
                }
                else if(choiceMade == 0){
                                    Debug.Log("rebel arttı rebel");

                    increaseRebel(30);
                }

                break;
            case 4:
                Debug.Log("Event 4 is executed");
                // anne çocuğunu gönderiyor
                if(choiceMade == 1){
                                    Debug.Log("çocuk gitti");
                    increaseRebel(20);
                    increaseMetal(20);
                    increaseElec(20);
                    increaseFood(20);

                    
                }
                if(choiceMade == 0){
                                    Debug.Log("çocuk kaldı");

                    decreaseOxygen(40);
                    
                }
                
                break;
            
            default:
                Debug.Log("Default case is executed");
                break;
        } 
        
    }
    
    int randomEventNum;

    public float minTime = 10.0f;
    public float maxTime = 30.0f;
    public float nextEventTime;
    public float elapsedTime;

    //public GameObject Canvas;
    private void Start()
    {
        nextEventTime = FindTimeRange();
        elapsedTime = 0f;
    }
    
    private void Update()
    {
        if(checkShelterStateLevels() != null){

            // Its calls event out of resource
            madeEventAffects(0);
        }

        if(Shelter.Instance.rebel < 30){
            // Its calls event rebel started
            madeEventAffects(2);
        }

        if(!Canvas.activeInHierarchy){
            elapsedTime += Time.deltaTime;
        }

        if (elapsedTime >= nextEventTime && !Canvas.activeInHierarchy)
        {
            
            executeEvent();
            nextEventTime = FindTimeRange();
            elapsedTime = 0f;
        }
        
    }

    private float FindTimeRange()
    {
        return Random.Range(minTime, maxTime);
    }
    
    public void executeEvent()
    {
        randomEventNum = Random.Range(1,5);

        callRandomEvent(randomEventNum);

        madeEventAffects(randomEventNum);
        
        Canvas.SetActive(true);
        
    }
    



}
