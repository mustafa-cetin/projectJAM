using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RoomManager : MonoBehaviour
{
    ShelterGrid shelterGrid;


    public Room SelectedRoomType{get;private set;}


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
    }
    public void SetSelectedRoomType(Room room){
        SelectedRoomType=room;
    }
    public void BuildRoom(ShelterGridTile tile){
        if (buildHelper.CanBuild(tile))
        {

            Debug.Log("selected");
            tile.SetIsOccupied(true);
            AudioManager.Instance.PlayConstructionSound();
            DecreaseRequirements(SelectedRoomType.roomPrice);

            Room buildedRoom=Instantiate(SelectedRoomType,transform);
            tile.SetRoom(buildedRoom);
            buildedRoom.transform.position=shelterGrid.GetWorldPosition(tile.GetPosition());
            if (Shelter.Instance.currentModeNew.Equals(Shelter.Instance.BuildMode))
            {
                buildHelper.ShowBuildablePlaces();
            }
        }


    }

    void Update()
    {
        /*
        if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject()) // Eğer UI üzerinde tıklama yoksa devam et
            {
                if (Shelter.Instance.currentMode!=Mode.None && Shelter.Instance.currentMode!=Mode.RoomEdit) return;
                Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.nearClipPlane;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            if (GetRoom(worldPosition)!=null)
            {
                Room clickedRoom = GetRoom(worldPosition);
                if (true)
                {

                }

            }




            }
        }
        */
    }


    public void DecreaseRequirements(Resource roomRequirement){
        Shelter.Instance.ChangeElectric(-1*roomRequirement.electric);
        Shelter.Instance.ChangeFood(-1*roomRequirement.food);
        Shelter.Instance.ChangeMetal(-1*roomRequirement.metal);
        Shelter.Instance.ChangeOxygen(-1*roomRequirement.oxygen);
    }



    public bool CheckLadderAtTheTopLine(ShelterGridTile gridTile){
        if (gridTile.GetPosition().y==10)
        {
            return true;
        }

        return false;



    }

    public bool CheckNeighboursIsOccupied(Vector2Int position){

        if (position.y==shelterGrid.GetShelterGridSizeY()-1 && position.x==0)
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
