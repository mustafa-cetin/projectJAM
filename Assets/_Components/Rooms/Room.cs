using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

    protected bool ready;
    public Resource roomPrice;

    protected int width=1;
    protected int height=1;


    protected float progress;
    protected Color color;
    public virtual void Start() {
        ready=false;
        progress=0f;
        color=Color.black;
    }
    public virtual void Update(){
        if (progress<10f)
        {
            progress+=5*Time.deltaTime;
            color=Color.HSVToRGB(0,0,progress/10);
            GetComponent<SpriteRenderer>().color=color;
        }else{
            ready=true;
        }
    }
    public bool IsBuildableTheTile(ShelterGrid shelterGrid,ShelterGridTile shelterGridTile){
        bool flag=false;
        if (shelterGridTile.GetPosition().y!=shelterGrid.GetShelterGridSizeY()-1 && shelterGridTile.GetPosition().x!=0)
        {

        ShelterGridTile[] shelterGridLine=shelterGrid.GetGridTileLine(shelterGridTile.GetPosition().y+1);
        foreach (var shelterGridTil in shelterGridLine)
        {
            if (shelterGridTil.IsOccupied)
            {

            if (shelterGridTil.GetRoom().CompareTag("LadderRoom"))
            {
                flag=true;
                break;
            }

            }
        }
        }

        else

        {
            flag=true;
        }

        if (flag)
        {
           return CheckValidation(shelterGrid,shelterGridTile);
        }

        return false;
    }
    public virtual bool CheckValidation(ShelterGrid shelterGrid,ShelterGridTile shelterGridTile){
        return true;
    }
}
