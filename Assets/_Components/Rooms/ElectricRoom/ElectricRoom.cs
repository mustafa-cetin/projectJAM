using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricRoom : ResourceRoom
{

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
            DecreaseCostsFromResources();
            AddIncomesToResources();
        }
        }else
        {
            timer=Time.time;
        }
    }
     public override string ToString()
    {
        return "Power Station";
    }

}
