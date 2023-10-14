using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoop : MonoBehaviour
{
    public float minTime = 10.0f;
    public float maxTime = 30.0f;
    private float nextEventTime;
    private float elapsedTime;

    private void Start()
    {
        nextEventTime = FindTimeRange();
        elapsedTime = 0f;
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= nextEventTime)
        {
            executeEvent();
            nextEventTime = FindTimeRange();
            elapsedTime = 0f;
        }
    }

    private float FindTimeRange()
    {
        return Random.Range(minTime, maxTime);
    }

    private void executeEvent()
    {
        Debug.Log("Event will be executed");
        SceneManager.LoadScene(0);
    }
}
