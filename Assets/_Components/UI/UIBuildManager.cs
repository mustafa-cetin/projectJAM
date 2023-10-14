using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBuildManager : MonoBehaviour
{
    [SerializeField]
    private BuildHelper buildHelper;


    public void EnterBuildMode(){
        buildHelper.SetBuildMode(true);
        buildHelper.ShowBuildablePlaces();
    }

    public void ShowRooms(){
        
    }
}
