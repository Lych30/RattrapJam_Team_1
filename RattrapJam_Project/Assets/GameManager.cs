using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static bool Standby = true;
    public GameObject PauseUI;
    public GameObject GameUI;


    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (Standby)
            {

                StartGame();

            }
         
        }
    }

    void StartGame()
    {
        GameObject.Find("Player").GetComponentInChildren<Animator>().SetTrigger("Start");
        PauseUI.SetActive(false);
        GameUI.SetActive(true);

    }

}
