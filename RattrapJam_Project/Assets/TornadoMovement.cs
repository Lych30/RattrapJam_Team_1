using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoMovement : MonoBehaviour
{
    public Transform Player;
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
        rb.velocity = new Vector2(5, 0);
    }
}
