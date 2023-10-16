using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelterGridTile
{
    private int x;
    private int y;
    private Room room;
    public bool IsOccupied{get;private set;}

    public Room GetRoom(){
        return room;
    }

    public void SetIsOccupied(bool IsOccupied){
        this.IsOccupied=IsOccupied;
    }

    public ShelterGridTile(int x,int y){
        this.x=x;
        this.y=y;
        IsOccupied=false;

    }

    public void SetRoom(Room newRoom){
        room=newRoom;
    }
    public Vector2Int GetPosition(){
        return new Vector2Int(x,y);
    }

}
