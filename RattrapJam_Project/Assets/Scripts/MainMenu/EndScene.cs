using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    public int index;
    public string levelName;
    public void playGame()
    {
        SceneManager.LoadScene("SceneKarim");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(levelName);

        }
    }

}
