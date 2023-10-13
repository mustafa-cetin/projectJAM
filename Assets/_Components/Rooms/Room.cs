using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

    protected bool ready;
    public RoomRequirement requirements;

    protected int width=1;
    protected int height=1;


    protected float progress;
    protected Color color;
    public virtual void Start() {
        ready=false;
        progress=0f;
        color=Color.white;
    }
    public virtual void Update(){
        if (progress!=100f)
        {
            progress+=20*Time.deltaTime;
            color.a=progress/10;
            GetComponent<SpriteRenderer>().color=color;
        }
    }
}
