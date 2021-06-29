
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
    private BoxCollider2D monCollider;

    private bool canSlide = true;
    private bool IsSliding;
    private float slideTimerMax = 2f;
    private float slideTimer;

    private SpriteRenderer sr;



    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        monCollider = gameObject.GetComponent<BoxCollider2D>();
        Physics2D.queriesStartInColliders = false;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);

        //JUMP
        if (Input.GetButton("Jump") && canJump && !IsSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
        }
        jumpCheck();


        //SLIDE
        if(Input.GetKeyDown(KeyCode.LeftControl) && canSlide)
        {  
            sr.color = new Color(255, 0, 0);
            StartCoroutine(Slide());
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            IsSliding = false;
            StartCoroutine(SlideCooldown());
        }

    }

    //SLIDE CODE
    IEnumerator SlideCooldown()
    {
        canSlide = false;
        yield return new WaitForSeconds(1f);
        slideTimer = slideTimerMax;
        canSlide = true;
    }
    IEnumerator Slide()
    {
        IsSliding = true;
        float y = monCollider.size.y;
        monCollider.size = new Vector2(monCollider.size.x, monCollider.size.y / 2);
        monCollider.offset = new Vector2(0, -0.04f);
        yield return new WaitForSeconds(1f);
        IsSliding = false;
        sr.color = new Color(255, 255, 255);
        monCollider.size = new Vector2(monCollider.size.x, y);
        monCollider.offset = new Vector2(0, 0);
        canSlide = true;
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
