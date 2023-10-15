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
        if (Worker!=null)
        {
        if (Time.time>=betweenTimeCount+timer && Shelter.Instance.Electric>=5 && ready)
        {
            timer=Time.time;
            Shelter.Instance.ChangeOxygen(Random.Range(1,Worker.endurance));
            Shelter.Instance.ChangeElectric(-1*1);
            Shelter.Instance.ChangeFood(-1*1);
        }
        }else
        {
            timer=Time.time;
        }
    }
}
