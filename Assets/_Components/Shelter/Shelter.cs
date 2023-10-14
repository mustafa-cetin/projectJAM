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

    public int electric = 100;

    public int food = 100;

    public int oxygen = 100;
    
    public int metal=100;

    [Range(0,100)]
    public int rebel = 0;


    public void ChangeElectric(int value){
        electric+=value;
        uiResourceManager.NotifyElectric(value);

    }
    public void ChangeFood(int value){
        food+=value;

        uiResourceManager.NotifyFood(value);

    }
    public void ChangeOxygen(int value){
        oxygen+=value;
        uiResourceManager.NotifyOxygen(value);

    }
    public void ChangeMetal(int value){
        metal+=value;
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

