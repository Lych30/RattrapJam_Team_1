using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LooseScript : MonoBehaviour
{
 void retry()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }
}
