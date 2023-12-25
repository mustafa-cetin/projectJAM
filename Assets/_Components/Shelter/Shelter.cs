using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelter : MonoBehaviour
{


[SerializeField]
    UIResourceManager uiResourceManager;
    public static Shelter Instance { get; private set; }
private void Awake()
{
    // If there is an instance, and it's not me, delete myself.

    if (Instance != null && Instance != this)
    {
        Destroy(this);
    }
    else
    {
        Instance = this;
    }
}
    public float timer;
    public List<Citizen> citizens;


    public IMode currentMode;
    public BuildMode BuildMode{get;private set;}
    public TerraformMode TerraformMode{get;private set;}
     public CitizenMode CitizenMode{get;private set;}
      public EmptyMode EmptyMode{get;private set;}

    public int Electric{get;private set;}

    public int Food{get;private set;}

    public int Oxygen{get;private set;}

    public int Metal{get;private set;}

    [Range(0,100)]
    public int rebel = 0;

    public string timeText;
    public int Day{get;private set;}
    public GameObject ending;
    [SerializeField]
    private Resource startingResources;


    private void Start() {
        EmptyMode=new EmptyMode();
        Shelter.Instance.currentMode=Shelter.Instance.EmptyMode;
        BuildMode= new BuildMode();
        TerraformMode=new TerraformMode();
        CitizenMode=new CitizenMode();

        Food=startingResources.food;
        Electric=startingResources.electric;
        Oxygen=startingResources.oxygen;
        Metal=startingResources.metal;
        timer=Time.time;
        Day=0;
        ending.SetActive(false);

    }
    private void Update() {

        if (Oxygen<=0 || Electric<=0 || Metal<=0 || Food<=0 || rebel>=100)
        {
        ending.SetActive(true);
            Time.timeScale=0;
        }

        if (Time.time>=48f+timer)
        {
            ChangeFood(-1*citizens.Count*2);
            ChangeOxygen(-1*citizens.Count*2);
            Day++;
            timer=Time.time;
        }
         timeText=((int)(Time.time-timer)/2).ToString();
    }

    public void ChangeElectric(int value){
        Electric+=value;
        uiResourceManager.NotifyElectric(value);

    }
    public void ChangeFood(int value){
        Food+=value;

        uiResourceManager.NotifyFood(value);

    }
    public void ChangeOxygen(int value){
        Oxygen+=value;
        uiResourceManager.NotifyOxygen(value);

    }
    public void ChangeMetal(int value){
        Metal+=value;
        uiResourceManager.NotifyMetal(value);

    }

    public string State = "Standart";


    public int planetTerraforming;

}


