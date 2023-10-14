using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildHelper : MonoBehaviour
{
    ShelterGrid shelterGrid;
    RoomManager roomManager;
    public bool BuildMode{get;private set;}

    [SerializeField]
    Transform referencePrefab;
    List<Transform> references;

    

    [SerializeField]
    Transform referenceHolder;
    void Start()
    {
        shelterGrid=GetComponent<ShelterGrid>();
        roomManager=GetComponent<RoomManager>();
        references=new List<Transform>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Shelter.Instance.currentMode==Mode.Build && roomManager.SelectedRoomType!=null)
        {
            if (!EventSystem.current.IsPointerOverGameObject()) // Eğer UI üzerinde tıklama yoksa devam et
            {
                // Oyun dünyası üzerinde bir şey yap

            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.nearClipPlane;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            if (shelterGrid.GetShelterGridTileWorldPosition(worldPosition)!=null)
            {
                roomManager.BuildRoom(shelterGrid.GetShelterGridTileWorldPosition(worldPosition));
            }
            
            }
        }
    }
    public void SetSelectedRoom(Room room){
        roomManager.SetSelectedRoomType(room);
    }
    public bool CanBuild(ShelterGridTile tile){
        return !tile.IsOccupied
         && roomManager.CheckNeighboursIsOccupied(tile.GetPosition())
          && roomManager.SelectedRoomType.IsBuildableTheTile(shelterGrid,tile)
           && IsMaterialsEnough(roomManager.SelectedRoomType.requirements);
    }
    public bool IsMaterialsEnough(RoomRequirement roomRequirement){
         return Shelter.Instance.food>=roomRequirement.food
          && Shelter.Instance.electric>=roomRequirement.electric
           && Shelter.Instance.metal>=roomRequirement.metal
           && Shelter.Instance.oxygen>=roomRequirement.oxygen;
    }
    public void ShowBuildablePlaces(){
        RemoveReferences();
        bool[,] buildableAreas=shelterGrid.GetBuildableAreaOnGrid(roomManager.SelectedRoomType);
        
        for (int x = 0; x < buildableAreas.GetLength(0); x++)
        {
            for (int y = 0; y < buildableAreas.GetLength(1); y++)
            {
                if (buildableAreas[x,y] && CanBuild(shelterGrid.GetShelterGridTile(new Vector2Int(x,y))))
                {
                    Transform reference=Instantiate(referencePrefab,referenceHolder);
                    reference.transform.position=shelterGrid.GetWorldPosition(new Vector2Int(x,y));
                    references.Add(reference); 
                }
            }
        }
    }
    public void RemoveReferences(){

        foreach (var item in references)
        {
            Destroy(item.gameObject);
        }
        references.Clear();
    }
    public void SetBuildMode(bool state){
        if (!state){
            Shelter.Instance.currentMode=Mode.None;
            RemoveReferences();
        }else{
            Shelter.Instance.currentMode=Mode.Build;
            roomManager.SetSelectedRoomType(null);
        }
    }
}
