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
public List<Citizen> citizens;

    public Mode currentMode=Mode.None;

    public int Electric{get;private set;}

    public int Food{get;private set;}

    public int Oxygen{get;private set;}
    
    public int Metal{get;private set;}

    [Range(0,100)]
    public int rebel = 0;

    private void Start() {
        Food=100;
        Electric=100;
        Oxygen=100;
        Metal=100;
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
    public enum Mode
    {
        None,
        Build,
        Character,
        RoomEdit,
        TerraformPanel
    }

