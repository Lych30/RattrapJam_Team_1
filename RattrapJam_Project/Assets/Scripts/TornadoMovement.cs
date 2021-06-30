using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoMovement : MonoBehaviour
{
    public GameObject LoseUI;
    Transform Player;
    Vector2 refvelocity;
    Rigidbody2D rb;
    float y;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        y = transform.position.y;
        Player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //if(Vector3.Distance(transform.position,Player.position)> 12)
            //rb.velocity = new Vector2(9.8f, 0);
            rb.velocity = new Vector2(10 + Player.GetComponent<Movements>().Multiplicateur,0);

        //if (Vector3.Distance(transform.position, Player.position) < 12)
           // rb.velocity = new Vector2(5, 0);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            LoseUI.SetActive(true);
            Pause();
        }
    }
    void Pause()
    {
        Time.timeScale = 0f;
    }
}
