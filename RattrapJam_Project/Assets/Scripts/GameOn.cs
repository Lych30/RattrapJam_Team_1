using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOn : MonoBehaviour
{
    public SpriteRenderer nuage;
    public SpriteRenderer Hills;
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
        nuage.color = new Color(0.3f, 0.3f, 0.3f, 1);
        Hills.color = new Color(0.6f, 0.6f, 0.6f, 1);
        Tornade.GetComponent<TornadoMovement>().enabled = true;
    }
}
