using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public TutorialPopUp[] tutorialPopUps;
    public RectTransform popupTransform;
    public TMP_Text popupText;
    public TutorialPopUp currentTutorialPopUp;
    int index=0;
    private void Start() {
        Time.timeScale=0;

        if (tutorialPopUps.Length!=0)
        {
            currentTutorialPopUp=tutorialPopUps[0];
            currentTutorialPopUp.disableGos();
            popupTransform.gameObject.SetActive(true);
            popupTransform.anchoredPosition=currentTutorialPopUp.position;
            popupText.text=currentTutorialPopUp.info;
        }
    }
    private void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            currentTutorialPopUp.enableGos();
            popupTransform.gameObject.SetActive(false);
            if (index!=tutorialPopUps.Length-1)
            {
                if (index>7)
                {
                Time.timeScale=1;
                }
            popupTransform.gameObject.SetActive(true);
            index++;
            currentTutorialPopUp=tutorialPopUps[index];
            currentTutorialPopUp.disableGos();
            popupTransform.anchoredPosition=currentTutorialPopUp.position;
            popupText.text=currentTutorialPopUp.info;

            }
        }

    }

}
