using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    ShelterGrid shelterGrid;


    Room selectedRoomType;
    [SerializeField]
    Room oxygenRoom;

    
    [SerializeField]
    Room ladderRoom;



    
    void Start()
    {
        shelterGrid=GetComponent<ShelterGrid>();
    }
    public void BuildRoom(ShelterGridTile tile){
        if (!tile.IsOccupied && (CheckNeighboursIsOccupied(tile.GetPosition())) && CheckLadderAtTheTopLine(tile) && CanBuild(selectedRoomType.requirements))
        {
            tile.SetIsOccupied(true);
            DecreaseRequirements(selectedRoomType.requirements);

            Room buildedRoom=Instantiate(selectedRoomType,transform);
            tile.SetRoom(buildedRoom);
            buildedRoom.transform.position=shelterGrid.GetWorldPosition(tile.GetPosition());

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
                selectedRoomType=oxygenRoom;
                BuildRoom(shelterGrid.GetShelterGridTileWorldPosition(worldPosition));
            }
            
        }else if (Input.GetMouseButtonDown(1))
        {
            
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.nearClipPlane;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            if (shelterGrid.GetShelterGridTileWorldPosition(worldPosition)!=null)
            {
                selectedRoomType=ladderRoom;
                BuildRoom(shelterGrid.GetShelterGridTileWorldPosition(worldPosition));
            }
        }
    }

    public bool CanBuild(RoomRequirement roomRequirement){


         return Shelter.Instance.food>=roomRequirement.food
          && Shelter.Instance.electric>=roomRequirement.electric
           && Shelter.Instance.water>=roomRequirement.water
           && Shelter.Instance.oxygen>=roomRequirement.oxygen;
        
    }

    public void DecreaseRequirements(RoomRequirement roomRequirement){
        Shelter.Instance.electric-=roomRequirement.electric;
        Shelter.Instance.food-=roomRequirement.food;
        Shelter.Instance.water-=roomRequirement.water;
        Shelter.Instance.oxygen-=roomRequirement.oxygen;
    }



    public bool CheckLadderAtTheTopLine(ShelterGridTile gridTile){
        if (gridTile.GetPosition().y==10)
        {
            return true;
        }
        
        ShelterGridTile[] shelterGridLine=shelterGrid.GetGridTileLine(gridTile.GetPosition().y+1);
        foreach (var shelterGridTile in shelterGridLine)
        {
            if (shelterGridTile.IsOccupied)
            {
                
            if (shelterGridTile.GetRoom().GetType()==ladderRoom.GetType())
            {
                Debug.Log("ladder var kardeş");
                return true;
            }
            
            }
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
