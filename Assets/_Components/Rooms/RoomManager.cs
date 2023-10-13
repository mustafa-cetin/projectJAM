using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    ShelterGrid shelterGrid;


    [SerializeField]
    Room selectedRoomType;

    ShelterGridTile startingTile;
    bool start;
    void Start()
    {
        shelterGrid=GetComponent<ShelterGrid>();
        start=true;
        startingTile=shelterGrid.GetShelterGridTile(new Vector2Int(0,10));
        BuildRoom(startingTile);
    }
    public void BuildRoom(ShelterGridTile tile){
        if (!tile.IsOccupied && (CheckNeighboursIsOccupied(tile.GetPosition())||start))
        {
            tile.SetIsOccupied(true);
            Room buildedRoom=Instantiate(selectedRoomType,transform);
            tile.SetRoom(buildedRoom);
            buildedRoom.transform.position=shelterGrid.GetWorldPosition(tile.GetPosition());
            start=false;

        }


    }

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.nearClipPlane;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            if (shelterGrid.GetShelterGridTileWorldPosition(worldPosition)!=null)
            {
                BuildRoom(shelterGrid.GetShelterGridTileWorldPosition(worldPosition));
            }
            
        }
    }

    public bool CheckNeighboursIsOccupied(Vector2Int position){
            List<Vector2Int> neighborsPositions=shelterGrid.GetNeighbors(position);
            foreach (var neighborPosition in neighborsPositions)
            {
                if (shelterGrid.GetShelterGridTile(neighborPosition).IsOccupied)
                {
                    return true;
                }
            }
            return false;
    }
    
    public int GetRoomCount(){
        return 0;
    }
}
