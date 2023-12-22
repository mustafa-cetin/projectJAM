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
        Shelter.Instance.BuildMode.init(buildHelper,roomsPanel);
        if (!Shelter.Instance.currentModeNew.Equals(Shelter.Instance.BuildMode))
        {
             Shelter.Instance.currentModeNew.exitMode();
            Shelter.Instance.currentModeNew=Shelter.Instance.BuildMode;
            Shelter.Instance.currentModeNew.enterMode();
        }else{
            Shelter.Instance.currentModeNew.exitMode();
        }
    }

    public void SetSelectedRoom(UIRoomElement roomElement){

        if (Shelter.Instance.currentModeNew.Equals(Shelter.Instance.BuildMode))
        {
        buildHelper.RemoveReferences();
        buildHelper.SetSelectedRoom(roomElement.room);
        buildHelper.ShowBuildablePlaces();
        }
    }

    public void ShowRooms(){

    }
}
