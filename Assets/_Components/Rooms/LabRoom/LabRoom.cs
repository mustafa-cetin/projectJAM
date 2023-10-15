using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabRoom : ResourceRoom
{
    [SerializeField]
    private float betweenTimeCount;

    private CitizenGenerator citizenGenerator;


    private float timer;
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
            Shelter.Instance.ChangeElectric(-15);
            Shelter.Instance.ChangeFood(-101);
        }
        }else
        {
            timer=Time.time;
        }
    }

}
