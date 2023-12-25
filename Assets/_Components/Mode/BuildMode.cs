using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMode : IMode
{
    private BuildHelper buildHelper;
    private GameObject roomsPanel;
    private GameObject closeButton;
    public override string ToString()
    {
        return "Build Mode";
    }

    public void init(BuildHelper buildHelper,GameObject roomsPanel,GameObject closeButton){
        this.buildHelper=buildHelper;
        this.roomsPanel=roomsPanel;
        this.closeButton=closeButton;
    }
    public void enterMode(){
            buildHelper.SetBuildMode(true);
            roomsPanel.SetActive(true);
            closeButton.SetActive(true);
    }
    public void exitMode()
    {
         Shelter.Instance.currentMode=Shelter.Instance.EmptyMode;
            buildHelper.RemoveReferences();
             roomsPanel.SetActive(false);
             closeButton.SetActive(false);
    }
}
