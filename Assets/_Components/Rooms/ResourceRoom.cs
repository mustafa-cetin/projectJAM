using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceRoom : Room
{

    public Citizen Worker{get;private set;}

    public void SetWorker(Citizen worker){
        Worker=worker;
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
}
