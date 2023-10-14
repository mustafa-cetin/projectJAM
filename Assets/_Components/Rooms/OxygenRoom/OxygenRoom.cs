using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenRoom : ResourceRoom
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
        if (Time.time>=betweenTimeCount+timer && Shelter.Instance.electric>=5 && ready)
        {
            timer=Time.time;
            Shelter.Instance.oxygen+=5;
        }
    }
}
