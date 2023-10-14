using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TerraformManager : MonoBehaviour
{

    private int terraformLevel=0;
    [SerializeField]
    private RoomRequirement[] levelByRequirements;

    [SerializeField]
    public GameObject panel;

    [SerializeField]
    public Image[] stageIcons;

    [SerializeField]
    public Sprite[] backgrounds;

    [SerializeField]
    public GameObject[] grounds;

    [SerializeField]
    public GameObject mainGround;
    [SerializeField]
    public GameObject[] tileBackgrounds;

    public SpriteRenderer background;


    
    [SerializeField]
    public TMP_Text oxygen,metal,food,electric;

    private void OnMouseDown() {
        
            if (!EventSystem.current.IsPointerOverGameObject()) // Eğer UI üzerinde tıklama yoksa devam et
            {
                if (Shelter.Instance.currentMode!=Mode.None && Shelter.Instance.currentMode!=Mode.TerraformPanel) return;
                ShowPanel();
                FillRequirements();
            }
    }
    public void ShowPanel(){
        Shelter.Instance.currentMode=Mode.TerraformPanel;
        panel.SetActive(true);
    }
    public void HidePanel(){
        Shelter.Instance.currentMode=Mode.None;
        panel.SetActive(false);
    }
    public void FillRequirements(){
        oxygen.text=levelByRequirements[terraformLevel].oxygen.ToString();
        metal.text=levelByRequirements[terraformLevel].metal.ToString();
        food.text=levelByRequirements[terraformLevel].food.ToString();
        electric.text=levelByRequirements[terraformLevel].electric.ToString();
    }

    public void UpdateEnvironment(){
        if (IsMaterialsEnough(levelByRequirements[terraformLevel]) && terraformLevel<3)
        {
            stageIcons[terraformLevel].color=Color.yellow;
            ChangeBackground();ChangeTileGrounds();ChangeTileBackgrounds();
            FillRequirements();
            terraformLevel++;
            if (terraformLevel>=3)
            {
                terraformLevel=2;
            }
            Debug.Log("area updated");
        }
    }
    public void ChangeTileGrounds(){
        mainGround.SetActive(false);
        foreach (var item in grounds)
        {
            item.SetActive(false);
        }
        grounds[terraformLevel].SetActive(true);
    }
    public void ChangeTileBackgrounds(){
        foreach (var item in tileBackgrounds)
        {
            item.SetActive(false);
        }
        tileBackgrounds[terraformLevel].SetActive(true);
    }
    public bool IsMaterialsEnough(RoomRequirement roomRequirement){
         return Shelter.Instance.food>=roomRequirement.food
          && Shelter.Instance.electric>=roomRequirement.electric
           && Shelter.Instance.metal>=roomRequirement.metal
           && Shelter.Instance.oxygen>=roomRequirement.oxygen;
    }
    public void ChangeBackground(){
        background.sprite=backgrounds[terraformLevel];
    }

    void Update()
    {

    }
}
