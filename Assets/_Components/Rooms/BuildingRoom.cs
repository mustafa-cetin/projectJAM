using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingRoom : Room
{
    public override bool CheckValidation(ShelterGrid shelterGrid,ShelterGridTile shelterGridTile){
        ShelterGridTile[] gridLine=shelterGrid.GetGridTileLine(shelterGridTile.GetPosition().y);
        
        foreach (var gridTile in gridLine)
        {
            if (gridTile.IsOccupied)
            {
                
            if (gridTile.GetRoom().CompareTag("LadderRoom"))
            {
                return true;
            }
            
            }
        }
        return false;
        
        }
}
