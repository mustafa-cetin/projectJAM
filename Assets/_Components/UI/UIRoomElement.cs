using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIRoomElement : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
{
    public Room room;


    private bool isMouseOver;
    private Button myButton;
    private UIBuildManager uiBuildManager;
    private void SetRoom(){
        uiBuildManager.SetSelectedRoom(this);
    }
    private void Start()
    {
        uiBuildManager=transform.parent.parent.GetComponent<UIBuildManager>();
       // infoPanel=transform.parent.parent.Find("InfoPanel").GetComponent<UIRoomInfoPanel>();
        myButton=GetComponent<Button>();
        // Başlangıçta info panelini kapalı olarak ayarlayın

    }
    private void OnEnable() {
        if (uiBuildManager==null)
        {
         uiBuildManager=transform.parent.parent.GetComponent<UIBuildManager>();
        }

        if (myButton==null)
        {
        myButton=GetComponent<Button>();
        }
        myButton.onClick.AddListener(SetRoom);

    }
    private void OnDisable() {
        myButton.onClick.RemoveListener(SetRoom);

    }
    private void Update() {

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Fare öğenin üzerine geldiğinde çağrılır
        uiBuildManager.SetBuildInfoPanel(true,room);
        OpenInfoPanel();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Fare öğeden çıktığında çağrılır
        uiBuildManager.SetBuildInfoPanel(false,room);
        CloseInfoPanel();
    }

    private void OpenInfoPanel()
    {


    }

    public void CloseInfoPanel()
    {

    }
}
