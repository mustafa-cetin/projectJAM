using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TutorialPopUp
{
    public Vector3 position;
    public string info;
    public GameObject[] willDisableGOs;

    public void disableGos(){
        foreach (GameObject gameObject in willDisableGOs)
        {
            gameObject.SetActive(false);
        }
    }
    public void enableGos(){
        foreach (GameObject gameObject in willDisableGOs)
        {
            gameObject.SetActive(true);
        }
    }

}
