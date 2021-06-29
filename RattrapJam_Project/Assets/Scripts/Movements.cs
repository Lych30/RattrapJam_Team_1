
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

    private bool canSlide;
    private bool IsSliding;
    private float slideTimerMax = 2f;
    private float slideTimer;

    private SpriteRenderer sr;



    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        monCollider = gameObject.GetComponent<Collider2D>();
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
        if(Input.GetKey(KeyCode.LeftControl) && slideTimer > 0f && canSlide)
        {
            slideTimer -= Time.deltaTime;
            IsSliding = true;
            sr.color = new Color(255, 0, 0);
        }
        else
        {
            IsSliding = false;
            sr.color = new Color(255, 255, 255);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            IsSliding = false;
            StartCoroutine(SlideCooldown());
        }

    }
    IEnumerator SlideCooldown()
    {
        canSlide = false;
        yield return new WaitForSeconds(1f);
        slideTimer = slideTimerMax;
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
