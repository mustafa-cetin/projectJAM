using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    private bool isPaused = false;

    public GameObject panel;

    //public GameObject Canvas;

    public GameObject Start;
    void Update()
    {
        // "ESC" tuşuna basıldığında oyunun durumu değiştirilir (durdurulur veya devam ettirilir).
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
                panel.SetActive(false);
              //  Canvas.SetActive(true);
                Start.SetActive(false);
            }
            else
            {
                Pause();
                panel.SetActive(true);
               // Canvas.SetActive(false);
                Start.SetActive(true);

            }
        }
    }

    // Oyunu duraklatma işlemi
    void Pause()
    {
        Time.timeScale = 0; // Zamanı duraklatır, bu da oyunu duraklatır.
        isPaused = true;
        // İsterseniz burada başka işlemler de ekleyebilirsiniz.
    }

    // Oyunu devam ettirme işlemi
    void ResumeGame()
    {
        Time.timeScale = 1; // Zamanı gerçek zamanlı hızda devam ettirir.
        isPaused = false;
        // İsterseniz burada başka işlemler de ekleyebilirsiniz.
    }
}
