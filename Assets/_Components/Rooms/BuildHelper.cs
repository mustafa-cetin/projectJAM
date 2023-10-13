using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildHelper : MonoBehaviour
{
    ShelterGrid shelterGrid;
    RoomManager roomManager;
    public bool BuildMode{get;private set;}

    [SerializeField]
    Transform referencePrefab;
    List<Transform> references;

    void Start()
    {
        shelterGrid=GetComponent<ShelterGrid>();
        roomManager=GetComponent<RoomManager>();
        BuildMode=true;
        references=new List<Transform>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            ShowBuildablePlaces();
        }
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
        foreach (var item in references)
        {
            Destroy(item.gameObject);
        }
        references.Clear();
        bool[,] buildableAreas=shelterGrid.GetBuildableAreaOnGrid(roomManager.SelectedRoomType);
        
        for (int x = 0; x < buildableAreas.GetLength(0); x++)
        {
            for (int y = 0; y < buildableAreas.GetLength(1); y++)
            {
                if (buildableAreas[x,y] && CanBuild(shelterGrid.GetShelterGridTile(new Vector2Int(x,y))))
                {
                    Transform reference=Instantiate(referencePrefab);
                    reference.transform.position=shelterGrid.GetWorldPosition(new Vector2Int(x,y));
                    references.Add(reference); 
                }
            }
        }
    }
}
