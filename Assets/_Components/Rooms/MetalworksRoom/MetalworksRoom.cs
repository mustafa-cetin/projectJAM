using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalworksRoom : ResourceRoom
{

    public override void Start() {
        base.Start();
        timer=Time.time;
    }
    public override void Update() {
        base.Update();

        if (Worker!=null)
        {
        if (Time.time>=betweenTimeCount+timer && Shelter.Instance.Electric>=10 && ready)
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
        return "Metal Workshop";
    }

}
