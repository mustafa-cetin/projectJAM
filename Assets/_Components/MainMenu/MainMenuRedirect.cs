using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuRedirect : MonoBehaviour
{
   public void GoGameScene(){
    SceneManager.LoadScene(1);
   }
}
