using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOn : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject Tornade;
    void Start()
    {
        Tornade = GameObject.Find("Tornade");
    }

    public void Activation()
    {
        GetComponentInParent<Movements>().enabled = true;
    }
    public void TornadeActivation()
    {
        Tornade.GetComponent<TornadoMovement>().enabled = true;
    }
}
