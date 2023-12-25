using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShelterGrid : MonoBehaviour
{
    [SerializeField]
    private int shelterGridSizeX,shelterGridSizeY;

    [SerializeField]
    private float cellSizeX,cellSizeY;

      ShelterGridTile[,] shelterGrid;

        [SerializeField]
      Room exampleRoom;
    public void Awake(){
        shelterGrid=new ShelterGridTile[shelterGridSizeX,shelterGridSizeY];
        for (int x = 0; x < shelterGridSizeX; x++)
        {
            for (int y = 0; y < shelterGridSizeY; y++)
            {
                shelterGrid[x,y]=new ShelterGridTile(x,y);
            }
        }
    }
    public int GetShelterGridSizeY(){
        return shelterGridSizeY;
    }
    private void Update() {
    }
    public Vector3 GetWorldPosition(Vector2Int position){
        int x=position.x;
        int y=position.y;
        return new Vector3(x*cellSizeX+cellSizeX/2,y*cellSizeY+cellSizeY/2,0)+transform.position;
    }
    public Vector2Int GetGridTilePosition(Vector3 worldPosition){
        float xPos=(worldPosition.x-transform.position.x)/(cellSizeX);
        float yPos=(worldPosition.y-transform.position.y)/(cellSizeY);
        int realX=Mathf.FloorToInt(xPos);
        int realY=Mathf.FloorToInt(yPos);
        return new Vector2Int(realX,realY);
    }

    public ShelterGridTile GetShelterGridTileWorldPosition(Vector3 worldPosition){
        return GetShelterGridTile(GetGridTilePosition(worldPosition));
    }
    public ShelterGridTile GetShelterGridTile(Vector2Int gridPosition){
        if (gridPosition.x>=0 && gridPosition.x<shelterGridSizeX && gridPosition.y>=0 && gridPosition.y<shelterGridSizeY)
        {
        return shelterGrid[gridPosition.x,gridPosition.y];
        }
        return null;
    }
    public ShelterGridTile[] GetGridTileLine(int y){
        ShelterGridTile[] shelterGridLine=new ShelterGridTile[shelterGridSizeX];
        for (int x = 0; x < shelterGridSizeX; x++)
        {
            shelterGridLine[x]=shelterGrid[x,y];
        }
        return shelterGridLine;
    }
    public bool[,] GetBuildableAreaOnGrid(Room room){
        bool[,] buildableArea=new bool[shelterGridSizeX,shelterGridSizeY];

        for (int x = 0; x < shelterGridSizeX; x++)
        {
            for (int y = 0; y < shelterGridSizeY; y++)
            {
                buildableArea[x,y]=room.IsBuildableTheTile(this,shelterGrid[x,y]);
            }
        }



        return buildableArea;
    }



    public List<Vector2Int> GetNeighbors(Vector2Int cellPosition)
    {
        List<Vector2Int> neighbors = new List<Vector2Int>();

        // Define the possible relative positions of neighbors
        Vector2Int[] relativePositions = {
            new Vector2Int(-1, 0), // left
            new Vector2Int(1, 0),  // right
            new Vector2Int(0, 1)  // top
            //new Vector2Int(0, -1)  // bottom
            // Add more directions if your grid allows diagonal movement
        };

        // Check each possible neighbor position
        foreach (var relativePosition in relativePositions)
        {
            Vector2Int neighbor = cellPosition + relativePosition;

            // Check if the neighbor is within the grid bounds
            if (neighbor.x >= 0 && neighbor.x < shelterGridSizeX && neighbor.y >= 0 && neighbor.y < shelterGridSizeY)
            {
                neighbors.Add(neighbor);
            }
        }

        return neighbors;
    }

    private void OnDrawGizmos() {

        for (int x = 0; x < shelterGridSizeX; x++)
        {
            for (int y = 0; y < shelterGridSizeY; y++)
            {
                Gizmos.DrawLine(new Vector3(x*cellSizeX,y*cellSizeY,0)+transform.position,new Vector3((x+1)*cellSizeX,y*cellSizeY,0)+transform.position);

                Gizmos.DrawLine(new Vector3(x*cellSizeX,y*cellSizeY,0)+transform.position,new Vector3(x*cellSizeX,(y+1)*cellSizeY,0)+transform.position);
            }
        }
    }


    }
