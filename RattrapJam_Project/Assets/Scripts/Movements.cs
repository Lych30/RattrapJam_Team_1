
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Movements : MonoBehaviour
{
    #region Variables
    private Rigidbody2D rb;
    public float speed;
    public float jump;
    float longueurCheckJump = 1.25f;
    public bool canJump;
    private BoxCollider2D monCollider;
    private bool invincible;
    public float Multiplicateur;
    float Initialgravity;
    public ParticleSystem dust;
    private bool canSlide = true;
    private bool IsSliding;
    private float slideTimerMax = 2f;
    private float slideTimer;

    private SpriteRenderer sr;

    private Animator animator;
    #endregion

    // Start is called before the first frame update
    void Awake()
    {
        dust = GetComponentInChildren<ParticleSystem>();
        sr = GetComponentInChildren<SpriteRenderer>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        monCollider = gameObject.GetComponent<BoxCollider2D>();
        Physics2D.queriesStartInColliders = false;
        animator = GetComponentInChildren<Animator>();
        Initialgravity = rb.gravityScale;
        //DEBUG
        
    }

    // Update is called once per frame
    void Update()
    {
        //CLAMP DU MULTIPLICATEUR
        Multiplicateur = Mathf.Clamp(Multiplicateur+Time.deltaTime/5,0,10);

        rb.velocity = new Vector2(speed + Multiplicateur, rb.velocity.y);

        if(rb.velocity.x > 0.1 && Mathf.Abs(rb.velocity.y)< 0.1 && canJump)
        {
            dust.Play();
        }
        //JUMP
        if (Input.GetButton("Jump") && canJump)
        {
            rb.gravityScale = Initialgravity;
            rb.velocity = new Vector2(rb.velocity.x, jump);
            IsSliding = false;
            animator.SetBool("Sliding", false);
        }
        jumpCheck();


        //SLIDE
        if(Input.GetKeyDown(KeyCode.LeftControl) && canSlide)
        {  
            StartCoroutine(Slide());
            
        }
        /*if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            IsSliding = false;
            StartCoroutine(SlideCooldown());
        }*/

    }

    //SLIDE CODE
    /*IEnumerator SlideCooldown()
    {
        canSlide = false;
        yield return new WaitForSeconds(1f);
        
        canSlide = true;
    }*/
    IEnumerator Slide()
    {
        dust.Play();
        slideTimer = slideTimerMax;
        if (!canJump)
        {
            rb.gravityScale *= 2;
        }
        canSlide = false;
        IsSliding = true;
        animator.SetBool("Sliding", true);
        monCollider.size = new Vector2(0.1106481f, 0.0633854f);
        monCollider.offset = new Vector2(0.006123053f, -0.09713551f);
        yield return new WaitForSeconds(1f);
        IsSliding = false;
        monCollider.size = new Vector2(0.05703655f, 0.183223f);
        monCollider.offset = new Vector2(0, -0.03731785f);
        canSlide = true;
        rb.gravityScale = Initialgravity;
        animator.SetBool("Sliding", false);
    }

    void jumpCheck()
    {
        animator.SetFloat("VelocityY", rb.velocity.y);
        RaycastHit2D hit;
        hit = Physics2D.Raycast(transform.position, -Vector2.up,longueurCheckJump);
        Debug.DrawRay(transform.position, -Vector2.up * longueurCheckJump, Color.red);

        if (hit.collider != null)
        {
            canJump = true;
            animator.SetBool("InJump", false);
           }
        else
        {
          
            canJump = false;
            animator.SetBool("InJump", true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("obstacle") && !invincible)
        {
            StartCoroutine(Hit());
        }
    }
    IEnumerator Hit()
    {
        animator.SetTrigger("Hit");
        invincible = true;
        speed *= 0.5f;
        sr.color = new Color(0, 0, 0, 0);
        yield return new WaitForSeconds(0.3f);
        sr.color = new Color(255, 255, 255, 255);
        yield return new WaitForSeconds(0.3f);
        sr.color = new Color(0, 0, 0, 0);
        speed *= 2;
        yield return new WaitForSeconds(0.3f);
        sr.color = new Color(255, 255, 255, 255);
        yield return new WaitForSeconds(0.3f);
        sr.color = new Color(0, 0, 0, 0);
        yield return new WaitForSeconds(0.3f);
        sr.color = new Color(255, 255, 255, 255);
        invincible = false;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawLine(transform.position,);
    }

}
