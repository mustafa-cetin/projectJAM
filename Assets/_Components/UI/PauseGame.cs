using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    private bool isPaused = false;

    public GameObject panel;

    private void Start()
    {
        panel.SetActive(false);
    }

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
            }
            else
            {
                Pause();
                panel.SetActive(true);
               // Canvas.SetActive(false);

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
