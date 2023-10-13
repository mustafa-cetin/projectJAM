using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderRoom : Room
{
    
    public override void Start() {
        base.Start();
    }
    public override void Update() {
        base.Update();
    }
    public override bool CheckValidation(ShelterGrid shelterGrid,ShelterGridTile shelterGridTile){
        ShelterGridTile[] gridLine=shelterGrid.GetGridTileLine(shelterGridTile.GetPosition().y);
        
        foreach (var gridTile in gridLine)
        {
            if (gridTile.IsOccupied)
            {
                
            if (gridTile.GetRoom().CompareTag("LadderRoom"))
            {
                Debug.Log("AYNI SATIRDA ZATEN MEVCUT");
                return false;
            }
            
            }
        }
        return true;
        
        }

}
