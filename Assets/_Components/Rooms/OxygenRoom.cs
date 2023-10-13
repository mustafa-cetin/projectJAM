using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenRoom : Room
{
    [SerializeField]
    private float betweenTimeCount;

    private float timer;
    private void Start() {
        timer=Time.time;
    }
    private void Update() {
        if (Time.time>=betweenTimeCount+timer && Shelter.Instance.electric>=5)
        {
            timer=Time.time;
            Shelter.Instance.oxygen+=5;
        }
    }
}
