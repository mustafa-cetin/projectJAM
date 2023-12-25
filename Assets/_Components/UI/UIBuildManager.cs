using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBuildManager : MonoBehaviour
{
    [SerializeField]
    private BuildHelper buildHelper;

    [SerializeField]
    private GameObject roomsPanel;
[SerializeField]
    private GameObject closeButton;

    private UIRoomInfoPanel infoPanel; // Info panelinizin referansı

    private bool isMouseOver;
    private Room whichRoomOnHover;
    public void SetBuildInfoPanel(bool isMouseOver,Room whichRoomOnHover){
        this.isMouseOver=isMouseOver;
        this.whichRoomOnHover=whichRoomOnHover;
    }
    private void Start() {
        roomsPanel.SetActive(false);
        closeButton.SetActive(false);
         if (infoPanel==null)
        {
        infoPanel=transform.Find("BuildInfoPanel").GetComponent<UIRoomInfoPanel>();
        }
        if (infoPanel != null)
        {
            infoPanel.gameObject.SetActive(false);
        }
    }
    private void Update() {
         if (isMouseOver)
        {
            if (infoPanel != null)
            {
                infoPanel.gameObject.SetActive(true); // Info panelini aç
                Vector3 position=Input.mousePosition;
                position.x+=10f;
                infoPanel.transform.position=position;
                infoPanel.FillInfoPanelWithRequirement(whichRoomOnHover.roomPrice);
            }
        }else{

        if (infoPanel != null)
        {
            infoPanel.gameObject.SetActive(false); // Info panelini kapat
        }
        }
    }

    public void SwitchBuildMode(){
        Shelter.Instance.BuildMode.init(buildHelper,roomsPanel,closeButton);
        if (!Shelter.Instance.currentMode.Equals(Shelter.Instance.BuildMode))
        {
             Shelter.Instance.currentMode.exitMode();
            Shelter.Instance.currentMode=Shelter.Instance.BuildMode;
            Shelter.Instance.currentMode.enterMode();
        }else{
            Shelter.Instance.currentMode.exitMode();
        }
    }

    public void SetSelectedRoom(UIRoomElement roomElement){

        if (Shelter.Instance.currentMode.Equals(Shelter.Instance.BuildMode))
        {
        buildHelper.RemoveReferences();
        buildHelper.SetSelectedRoom(roomElement.room);
        roomsPanel.SetActive(false);
        closeButton.SetActive(false);
        isMouseOver=false;
        buildHelper.ShowBuildablePlaces();
        }
    }

    public void ShowRooms(){

    }
}
