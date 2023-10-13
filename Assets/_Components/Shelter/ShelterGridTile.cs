using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelterGridTile
{
    private int x;
    private int y;
    private bool buildable;
    private Room room;


    public void SetRoom(Room newRoom){
        room=newRoom;
    }

}
