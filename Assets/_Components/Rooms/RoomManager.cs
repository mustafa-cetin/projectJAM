using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    ShelterGrid shelterGrid;


    public Room SelectedRoomType{get;private set;}
    [SerializeField]
    Room oxygenRoom;

    
    [SerializeField]
    Room ladderRoom;


    private BuildHelper buildHelper;

    public Vector3 GetRoomCoordinates(Vector3 position){
        return shelterGrid.GetWorldPosition(shelterGrid.GetGridTilePosition(position));
    }
    public Room GetRoom(Vector3 position){
        return shelterGrid.GetShelterGridTileWorldPosition(position).GetRoom();
    }
    public int GetElevation(Vector3 position){
        return shelterGrid.GetGridTilePosition(position).y;
    }
    public Vector3 GetLadderRoomCoordinatesByY(int y){
        ShelterGridTile[] shelterGridTileLine=shelterGrid.GetGridTileLine(y);
        foreach (var item in shelterGridTileLine)
        {
            if (item.GetRoom()!=null)
            {
            if (item.GetRoom().CompareTag("LadderRoom"))
            {
                return shelterGrid.GetWorldPosition(item.GetPosition());
            }
            }
        }
        return Vector3.zero;
    }
    
    void Start()
    {
        buildHelper=GetComponent<BuildHelper>();
        shelterGrid=GetComponent<ShelterGrid>();
        SelectedRoomType=ladderRoom;
    }
    public void SetSelectedRoomType(Room room){
        SelectedRoomType=room;
    }
    public void BuildRoom(ShelterGridTile tile){
        if (buildHelper.CanBuild(tile))
        {

            tile.SetIsOccupied(true);
            AudioManager.Instance.PlayConstructionSound();
            DecreaseRequirements(SelectedRoomType.requirements);

            Room buildedRoom=Instantiate(SelectedRoomType,transform);
            tile.SetRoom(buildedRoom);
            buildedRoom.transform.position=shelterGrid.GetWorldPosition(tile.GetPosition());
            if (Shelter.Instance.currentMode==Mode.Build)
            {
                buildHelper.ShowBuildablePlaces();
            }
        }


    }

    void Update()
    {
        
    }


    public void DecreaseRequirements(RoomRequirement roomRequirement){
        Shelter.Instance.electric-=roomRequirement.electric;
        Shelter.Instance.food-=roomRequirement.food;
        Shelter.Instance.metal-=roomRequirement.metal;
        Shelter.Instance.oxygen-=roomRequirement.oxygen;
    }



    public bool CheckLadderAtTheTopLine(ShelterGridTile gridTile){
        if (gridTile.GetPosition().y==10)
        {
            return true;
        }
        
        return false;
        
            
        
    }

    public bool CheckNeighboursIsOccupied(Vector2Int position){
        
        if (position.y==10 && position.x==0)
        {
            return true;
        }
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
