using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIRoomElement : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
{
    public Room room;

    public UIRoomInfoPanel infoPanel; // Info panelinizin referansı

    private bool isMouseOver;

    private void Start()
    {
        infoPanel=transform.parent.parent.Find("InfoPanel").GetComponent<UIRoomInfoPanel>();
        // Başlangıçta info panelini kapalı olarak ayarlayın
        if (infoPanel != null)
        {
            infoPanel.gameObject.SetActive(false);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Fare öğenin üzerine geldiğinde çağrılır
        isMouseOver = true;
        OpenInfoPanel();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Fare öğeden çıktığında çağrılır
        isMouseOver = false;
        CloseInfoPanel();
    }

    private void OpenInfoPanel()
    {

        if (isMouseOver)
        {
            if (infoPanel != null)
            {
                infoPanel.gameObject.SetActive(true); // Info panelini aç
                Vector3 position=infoPanel.transform.localPosition;
                position.y=transform.localPosition.y+80f;
                infoPanel.transform.localPosition=position;
                infoPanel.FillInfoPanelWithRequirement(room.roomPrice);
            }
        }
    }

    private void CloseInfoPanel()
    {
        if (infoPanel != null)
        {
            infoPanel.gameObject.SetActive(false); // Info panelini kapat
        }
    }
}
