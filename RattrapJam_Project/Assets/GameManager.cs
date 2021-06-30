using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject PauseUI;
    public GameObject GameUI;
    void Start()
    {
        Pause();
    }


    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (GameIsPaused)
            {

                StartGame();

            }
         
        }
    }

    void StartGame()
    {
        PauseUI.SetActive(false);
        GameUI.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;

    }
    void Pause()
    {
        
        PauseUI.SetActive(true);
        GameUI.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
