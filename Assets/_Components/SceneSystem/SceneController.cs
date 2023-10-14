using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private static string sceneName;

    private void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
    }

    public static string GetSceneName()
    {
        return sceneName;
    }
}
