using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceRoom : Room
{
    public int level;
    public Sprite[] levelSprites;
    public Resource[] roomRequirementsByLevel;

    [SerializeField]
    protected float betweenTimeCount;

    protected float timer;

       [SerializeField]
    protected Resource income;
    [SerializeField]
    protected Resource outgoing;

    public Citizen Worker{get;private set;}

    public void SetWorker(Citizen worker){
        Worker=worker;
    }
    public override void Start() {
        base.Start();
        level=0;
    }
    public void UpdateRoom(){
        if (level<=3)
        {
        level++;
        GetComponent<SpriteRenderer>().sprite=levelSprites[level];
        }
    }

    public override bool CheckValidation(ShelterGrid shelterGrid,ShelterGridTile shelterGridTile){
        ShelterGridTile[] gridLine=shelterGrid.GetGridTileLine(shelterGridTile.GetPosition().y);
        if (shelterGridTile.GetPosition().x-1>=0)
        {
            if (gridLine[shelterGridTile.GetPosition().x-1].IsOccupied)
            {
                return true;
            }
        }
        if (shelterGridTile.GetPosition().x+1<gridLine.Length)
        {
            if (gridLine[shelterGridTile.GetPosition().x+1].IsOccupied)
            {
                return true;
            }
        }
        return false;
        }


        protected void DecreaseCostsFromResources(){
            Shelter.Instance.ChangeElectric(-outgoing.electric);
            Shelter.Instance.ChangeOxygen(-outgoing.oxygen);
            Shelter.Instance.ChangeMetal(-outgoing.metal);
            Shelter.Instance.ChangeFood(-outgoing.food);
        }

        protected void AddIncomesToResources(){
            Shelter.Instance.ChangeElectric(income.electric);
            Shelter.Instance.ChangeOxygen(income.oxygen);
            Shelter.Instance.ChangeMetal(income.metal);
            Shelter.Instance.ChangeFood(income.food);
        }

}
