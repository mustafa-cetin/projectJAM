using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricRoom : ResourceRoom
{
    [SerializeField]
    private float betweenTimeCount;

    private float timer;
    public override void Start() {
        base.Start();
        timer=Time.time;
    }
    public override void Update() {
        base.Update();
        if (Worker!=null)
        {
        if (Time.time>=betweenTimeCount+timer && Shelter.Instance.Food>=5 && ready)
        {
            timer=Time.time;
            Shelter.Instance.ChangeElectric(8);
            Shelter.Instance.ChangeFood(-2);
        }
        }else
        {
            timer=Time.time;
        }
    }

}
