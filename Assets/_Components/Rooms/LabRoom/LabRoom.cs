using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabRoom : ResourceRoom
{


    private CitizenGenerator citizenGenerator;
    public override void Start() {
        base.Start();
        timer=Time.time;
        citizenGenerator=FindAnyObjectByType<CitizenGenerator>();
    }
    public override void Update() {
        base.Update();
        if (Worker!=null)
        {
        if (Time.time>=betweenTimeCount+timer && Shelter.Instance.Food>=101 && ready)
        {
            timer=Time.time;
            Vector3 position=transform.position;
            position.y-=1.5f;
            citizenGenerator.defineCitizenP(position);
            timer=Time.time;
            DecreaseCostsFromResources();
            AddIncomesToResources();
        }
        }else
        {
            timer=Time.time;
        }
    }

}
