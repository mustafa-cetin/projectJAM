using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class EventGenerator : MonoBehaviour
{

    public Events[] EventsArray;

    public TMP_Text mainText;

    public TMP_Text button1Text;

    public TMP_Text button2Text;

    public int choiceMade;
    public void callRandomEvent(int randomEventNum){

        Events currentEvents = EventsArray[randomEventNum];

        mainText.text = currentEvents.Event;

        button1Text.text = currentEvents.EventChoices[0];

        button2Text.text = currentEvents.EventChoices[1];

        
    }
    void checkShelterStateLevels(){
        if(Shelter.Instance.happiness < 30){
            Shelter.Instance.State = "Unhappy";
        }
        if(Shelter.Instance.electric < 30){
            Shelter.Instance.State = "PowerOutage";
        }
        if(Shelter.Instance.food < 30){
            Shelter.Instance.State = "Hungry";
        }
        if(Shelter.Instance.oxygen < 30){
            Shelter.Instance.State = "DeprivedOxygen";
        }
    }

    void increaseHapp(int number){
        Shelter.Instance.happiness += number;
    }

    void decreaseHapp(int number){
        Shelter.Instance.happiness -= number;
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
        switch (eventNum)
        {
            case 0:
                Debug.Log("Event 0 is executed");
                if(choiceMade == 1){

                }
                else if(choiceMade == 2){

                }
                

                break;
            case 1:
                Debug.Log("Event 1 is executed");
                if(choiceMade == 1){
                    Debug.Log("Welcome them with open arms");
                    increaseFood(30);
                    increaseMetal(40);

                    int prob = chance50();

                    if(prob == 1){
                        increaseHapp(40);
                    }
                    else if(prob == 0){
                        decreaseHapp(40);
                    }
                }
                else if(choiceMade == 2){
                    Debug.Log("Turn them away(Nothing Happens)");

                }
                break;
            case 2:
                Debug.Log("Event 2 is executed");
                // After Citizens
                break;
            case 3:
                Debug.Log("Event 3 is executed");
                // Mutluluk azalırsa case
                break;
            case 4:
                Debug.Log("Event 4 is executed");
                //citizen scout system
                break;
            case 5:
                Debug.Log("Event 5 is executed");
                if(choiceMade == 1){
                    decreaseHapp(30);
                    increaseElec(10);
                    increaseMetal(20);
                }
                else if(choiceMade == 2){
                    decreaseFood(20);
                    increaseHapp(30);
                }
                break;
            case 6:
                Debug.Log("Event 6 is executed");
                if(choiceMade == 1){
                    decreaseHapp(30);
                }
                else if(choiceMade == 2){
                    increaseHapp(30);
                    increaseOxygen(20);
                    decreaseMetal(30);
                    decreaseFood(20);
                    decreaseElec(10);
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
        randomEventNum = Random.Range(1,7);

        Debug.Log(randomEventNum);

        callRandomEvent(randomEventNum);

        madeEventAffects(randomEventNum);
        
        Canvas.SetActive(true);
        
    }
    



}
