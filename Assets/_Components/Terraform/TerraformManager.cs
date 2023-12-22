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
    private Resource[] levelByRequirements;

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


    private void Start() {
    }
    private void OnMouseDown() {

            if (!EventSystem.current.IsPointerOverGameObject()) // Eğer UI üzerinde tıklama yoksa devam et
            {
                Shelter.Instance.TerraformMode.init(panel);
                Shelter.Instance.currentModeNew.exitMode();
                Shelter.Instance.currentModeNew=Shelter.Instance.TerraformMode;
                Shelter.Instance.currentModeNew.enterMode();
                FillRequirements();
            }
    }

    public void ShowPanel(){
        Shelter.Instance.currentMode=Mode.TerraformPanel;
        panel.SetActive(true);
    }
    public void HidePanel(){
        Shelter.Instance.currentModeNew.exitMode();
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

            DecreaseRequirements(levelByRequirements[terraformLevel]);
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

    public void DecreaseRequirements(Resource roomRequirement){
        Shelter.Instance.ChangeElectric(-1*roomRequirement.electric);
        Shelter.Instance.ChangeFood(-1*roomRequirement.food);
        Shelter.Instance.ChangeMetal(-1*roomRequirement.metal);
        Shelter.Instance.ChangeOxygen(-1*roomRequirement.oxygen);
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
    public bool IsMaterialsEnough(Resource roomRequirement){
         return Shelter.Instance.Food>=roomRequirement.food
          && Shelter.Instance.Electric>=roomRequirement.electric
           && Shelter.Instance.Metal>=roomRequirement.metal
           && Shelter.Instance.Oxygen>=roomRequirement.oxygen;
    }
    public void ChangeBackground(){
        background.sprite=backgrounds[terraformLevel];
    }


}
