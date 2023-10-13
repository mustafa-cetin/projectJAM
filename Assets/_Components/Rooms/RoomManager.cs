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

    
    void Start()
    {
        buildHelper=GetComponent<BuildHelper>();
        shelterGrid=GetComponent<ShelterGrid>();
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
            buildHelper.ShowBuildablePlaces();
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
                SelectedRoomType=oxygenRoom;
                BuildRoom(shelterGrid.GetShelterGridTileWorldPosition(worldPosition));
            }
            
        }else if (Input.GetMouseButtonDown(1))
        {
            
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.nearClipPlane;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            if (shelterGrid.GetShelterGridTileWorldPosition(worldPosition)!=null)
            {
                SelectedRoomType=ladderRoom;
                BuildRoom(shelterGrid.GetShelterGridTileWorldPosition(worldPosition));
            }
        }
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
        
        if (position.y==10)
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
