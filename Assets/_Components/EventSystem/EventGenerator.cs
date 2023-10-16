using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class EventGenerator : MonoBehaviour
{
    public Image eventBackground;

    public Events[] EventsArray;

    public TMP_Text mainText;

    public TMP_Text button1Text;

    public TMP_Text button2Text;

    public CitizenGenerator citizenGenerator;

    public int choiceMade = 1;
    public void callRandomEvent(int randomEventNum){

        Events currentEvents = EventsArray[randomEventNum];

        Sprite currentSprite = EventsArray[randomEventNum].Background;
        
        eventBackground.sprite = currentSprite;

        mainText.text = currentEvents.Event;

        button1Text.text = currentEvents.EventChoices[0];

        button2Text.text = currentEvents.EventChoices[1];

        
    }
    string checkShelterStateLevels(){
        if(Shelter.Instance.Electric < 30){
            return "Electric";
        }
        if(Shelter.Instance.Food < 30){
            return "Food";
        }
        if(Shelter.Instance.Oxygen < 30){
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
        Shelter.Instance.ChangeFood(number);
    }

    void decreaseFood(int number){
        Shelter.Instance.ChangeFood(-1*number);
    }
    void increaseOxygen(int number){
        Shelter.Instance.ChangeOxygen(number);
    }

    void decreaseOxygen(int number){
        Shelter.Instance.ChangeOxygen(-1*number);
    }
    void increaseElec(int number){
        Shelter.Instance.ChangeElectric(number);
    }

    void decreaseElec(int number){
        Shelter.Instance.ChangeElectric(-1*number);
    }
    void increaseMetal(int number){
        Shelter.Instance.ChangeMetal(number);
    }

    void decreaseMetal(int number){
        Shelter.Instance.ChangeMetal(-1*number);
    }

    int chance50(){
        int result = Random.Range(0, 2); // 0 veya 1 rastgele bir sayı üretir.
        return result;
    }

    public GameObject Choice1;
    public GameObject Choice2;

    public GameObject Canvas;

    public void Chosed1(){
        choiceMade = 1;
        
        Canvas.SetActive(false);

        madeEventAffects(eventNum);
    }

    public void Chosed2(){
        choiceMade = 2; 

        Canvas.SetActive(false);

        madeEventAffects(eventNum);
    }
    
    
    
    
    public void madeEventAffects(int eventNum){
        
        int prob = chance50();
        Debug.Log(choiceMade);

        Time.timeScale=1;

        switch (eventNum)
        {
            case 0:
                Debug.Log("Girdi  choi " + choiceMade);

                if(choiceMade == 1){

                    decreaseMetal(30);
                    decreaseRebel(10);
                }
                else if(choiceMade == 2){
                    Debug.Log("Girdi rebel artmadı");
                    increaseRebel(20);
                }
                

                break;
            case 1:
                if(choiceMade == 1){
                    increaseFood(30);
                    increaseMetal(40);

                    for(int i=0;i<3;i++){
                        citizenGenerator.defineCitizen();
                    }
                    


                    prob = chance50();

                    if(prob == 0){
                        increaseRebel(20);
                    }
                    else if(prob == 1){
                        decreaseRebel(20);
                    }
                }
                
                break;
            case 2:
                            
                if(choiceMade == 1){

                    decreaseRebel(10);
                    decreaseMetal(30);
                    decreaseFood(30);
                    
                }
                if(choiceMade == 2){
                    prob = chance50();
                    
                    if(prob == 1){
                        decreaseRebel(Shelter.Instance.rebel);
                    }
                    else if(prob == 0){
                        decreaseRebel(20);
                    }
                }

                


                break;
            case 3:

                if(choiceMade == 1){
                    increaseRebel(30);
                }
                else if(choiceMade == 2){
                    decreaseMetal(30);
                    
                }

                break;
            case 4:
                if(choiceMade == 1){
                    increaseRebel(20);
                    increaseMetal(20);
                    increaseElec(20);
                    increaseFood(20);

                    
                }
                if(choiceMade == 2){
                    decreaseMetal(20);
                    decreaseFood(20);
                    decreaseRebel(30);
                    
                }
                
                break;
            case 5:
                if(choiceMade == 1){
                    increaseRebel(20);

                    increaseFood(50);

                    
                }
                if(choiceMade == 2){
                    decreaseMetal(50);
                    decreaseRebel(20);
                    
                }
                break;
            case 6:
                if(choiceMade == 1){
                    decreaseMetal(20);
                    
                }
                if(choiceMade == 2){
                    increaseOxygen(50);
                }  
                break; 
             case 7:
                if(choiceMade == 1){
                    decreaseElec(40);
                    
                }
                if(choiceMade == 2){
                   decreaseOxygen(30);
                }
                break; 
            case 8:
                if(choiceMade == 1){
                    decreaseRebel(Shelter.Instance.rebel);
                    increaseMetal(20);
                    
                }
                if(choiceMade == 2){
                    increaseRebel(30);
                    decreaseFood(80);
                }
                break;       
            case 9:
                if(choiceMade == 1){
                    increaseMetal(20);
                    increaseRebel(30);
                    increaseFood(50);
                    
                    
                }
                if(choiceMade == 2){
                    increaseElec(30);
                    increaseFood(30);
                    increaseMetal(30);
                    increaseOxygen(30);
                    decreaseRebel(10);
                }   
                break;
            
        } 
        
    }
    
    
    //int randomEventNum;

    public int eventNum =-1;

    public float minTime = 10.0f;
    public float maxTime = 30.0f;
    public float nextEventTime;
    public float elapsedTime;

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
            if(eventNum<9){
                eventNum+=1;
            }
            
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

        Time.timeScale=0;
        callRandomEvent(eventNum);

      //  madeEventAffects(choiceMade);


        Debug.Log("Vhoice exe . "+ choiceMade);

        //randomEventNum = Random.Range(1,5);

       // callRandomEvent(randomEventNum);

       // madeEventAffects(randomEventNum);
        
        Canvas.SetActive(true);
        
    }
    



}
