
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movements : MonoBehaviour
{
    #region Variables
    private Rigidbody2D rb;
    public float speed;
    public float jump;
    float longueurCheckJump = 1.5f;
    public bool canJump;
    private BoxCollider2D monCollider;

    private float Multiplicateur;

    private bool canSlide = true;
    private bool IsSliding;
    private float slideTimerMax = 2f;
    private float slideTimer;

    private SpriteRenderer sr;
    #endregion

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
        //CLAMP DU MULTIPLICATEUR
        Multiplicateur = Mathf.Clamp(Multiplicateur+Time.deltaTime/20,0,10);

        rb.velocity = new Vector2(speed + Multiplicateur, rb.velocity.y);

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
      
        monCollider.size = new Vector2(0.1106481f, 0.0633854f);
        monCollider.offset = new Vector2(0.006123053f, -0.09713551f);
        yield return new WaitForSeconds(1f);
        IsSliding = false;
        sr.color = new Color(255, 255, 255);
        monCollider.size = new Vector2(0.05703655f, 0.183223f);
        monCollider.offset = new Vector2(0, -0.03731785f);
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("obstacle"))
        {
            Debug.Log("ouch");
            rb.AddForce(new Vector2(-10, 0));
        }
    }


}
