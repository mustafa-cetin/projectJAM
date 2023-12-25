using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerraformMode : IMode
{
    private GameObject panel;
      public override string ToString()
    {
        return "Terraform Mode";
    }
    public void init(GameObject panel){
        this.panel=panel;
    }
    public void enterMode()
    {
        panel.SetActive(true);
    }

    public void exitMode()
    {
        Shelter.Instance.currentMode=Shelter.Instance.EmptyMode;
        panel.SetActive(false);
    }
}
