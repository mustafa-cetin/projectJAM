using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{
    private float timer;
    void Start()
    {
        timer=Time.time;
    }

    void Update()
    {
        if (Time.time>=1f+timer)
        {
            Destroy(gameObject);
            
        }        
    }
}
