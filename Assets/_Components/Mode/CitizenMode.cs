using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitizenMode : IMode
{
    private GameObject panel;
    private CitizenGenerator citizenGen;
          public override string ToString()
    {
        return "Citizen Mode";
    }
    public void init(GameObject panel,CitizenGenerator citizenGen){
        this.panel=panel;
        this.citizenGen=citizenGen;
    }

    public void enterMode()
    {
          // Shelter.Instance.currentModeNew.exitMode();


             //   SelectedCitizen=clickedCitizen;
               // Shelter.Instance.CitizenMode.SetSelectedCitizen(SelectedCitizen);

                citizenGen.ShowStatPanel();
               citizenGen. SelectedCitizen.ChangeSelectedValue(true);
              //  Shelter.Instance.CitizenMode.init(panel,this);
                //Shelter.Instance.currentModeNew=Shelter.Instance.CitizenMode;
               // Shelter.Instance.currentModeNew.enterMode();

    }

    public void exitMode()
    {
        Shelter.Instance.currentMode=Shelter.Instance.EmptyMode;
       citizenGen.SelectedCitizen.ChangeSelectedValue(false);
        citizenGen.SetSelectedCitizenNull();
        panel.SetActive(false);
    }
}
