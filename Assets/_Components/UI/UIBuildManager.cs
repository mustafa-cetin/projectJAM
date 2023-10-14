using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBuildManager : MonoBehaviour
{
    [SerializeField]
    private BuildHelper buildHelper;


    [SerializeField]
    private GameObject roomsPanel;
    private void Start() {
        roomsPanel.SetActive(false);
    }

    public void SwitchBuildMode(){
        if (Shelter.Instance.currentMode!=Mode.None && Shelter.Instance.currentMode!=Mode.Build) return;

        if (Shelter.Instance.currentMode==Mode.Build)
        {
            buildHelper.SetBuildMode(false);
            roomsPanel.SetActive(false);
        }else{
            buildHelper.SetBuildMode(true);
            roomsPanel.SetActive(true);
        }
    }

    public void SetSelectedRoom(UIRoomElement roomElement){
        if (Shelter.Instance.currentMode==Mode.Build)
        {
        buildHelper.RemoveReferences();
        buildHelper.SetSelectedRoom(roomElement.room);
        buildHelper.ShowBuildablePlaces();
        }
    }

    public void ShowRooms(){

    }
}
