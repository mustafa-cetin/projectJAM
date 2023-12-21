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
        Invoke("OpenInfoPanel", .5f); // 2 saniye sonra info panelini aç
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
                infoPanel.transform.position=transform.position+new Vector3(100,0,0);
                infoPanel.FillInfoPanelWithRequirement(room.requirements);
            }
        }
    }

    private void CloseInfoPanel()
    {
        if (infoPanel != null)
        {
            infoPanel.gameObject.SetActive(false); // Info panelini kapat
        }
        CancelInvoke("OpenInfoPanel"); // Eğer 2 saniye beklenmeden çıkılırsa planlanmış açma işlemini iptal et
    }
}
