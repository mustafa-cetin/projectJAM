using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenRoom : ResourceRoom
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
        if (Time.time>=betweenTimeCount+timer && Shelter.Instance.Electric>=5 && ready)
        {
            timer=Time.time;
            Shelter.Instance.ChangeFood(3);
            Shelter.Instance.ChangeElectric(-1*2);
        }
        }else
        {
            timer=Time.time;
        }
    }

}
