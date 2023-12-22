using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMode : IMode
{
    private BuildHelper buildHelper;
    private GameObject roomsPanel;
    public override string ToString()
    {
        return "Build Mode";
    }

    public void init(BuildHelper buildHelper,GameObject roomsPanel){
        this.buildHelper=buildHelper;
        this.roomsPanel=roomsPanel;
    }
    public void enterMode(){
            buildHelper.SetBuildMode(true);
            roomsPanel.SetActive(true);
    }
    public void exitMode()
    {
        Debug.Log("çalıştı");
         Shelter.Instance.currentModeNew=Shelter.Instance.EmptyMode;
            buildHelper.RemoveReferences();
             roomsPanel.SetActive(false);
    }
}
