
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movements : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float jump;
    float longueurCheckJump = 1.1f;
    private bool canJump;
    private Collider2D monCollider;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        monCollider = gameObject.GetComponent<Collider2D>();
        Physics2D.queriesStartInColliders = false;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);

        if (Input.GetButton("Jump") && canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
        }
        jumpCheck();

    }
    void jumpCheck()
    {
        RaycastHit2D hit;
        hit = Physics2D.Raycast(transform.position, -Vector2.up, monCollider.bounds.extents.y * longueurCheckJump);
        Debug.DrawRay(transform.position, -Vector2.up * monCollider.bounds.extents.y * longueurCheckJump, Color.red);

        if (hit.collider != null)
        {
            canJump = true;
            
        }
        else
        {
            canJump = false;

        }
    }
 
}
