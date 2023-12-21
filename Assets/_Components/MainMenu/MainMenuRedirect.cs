using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuRedirect : MonoBehaviour
{
   [SerializeField]
   private TMP_Text versionText;
   private void Start() {
      versionText.text="Version: "+Application.version;
   }
   public void GoGameScene(){
    SceneManager.LoadScene(1);
   }
}
