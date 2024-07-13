using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    public Rigidbody2D theRB;

    public float moveSpeed;
    public float jumpForce;
    public float runSpeed;
    private float activeSpeed;


    private bool isGrounded;
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool canDoubleJump;


    public Animator anim;


    public float knockbackLength, knowbackSpeed;
    private float knockbackCounter;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            AudioManager.instance.StopMusic();
        }

        if (Time.timeScale == 0f) return;
        if (knockbackCounter <= 0)
        {

        
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);

        //     theRB.velocity = new Vector2 (Input.GetAxisRaw("Horizontal")* moveSpeed, theRB.velocity.y);

        activeSpeed = moveSpeed;

        if (Input.GetKey(KeyCode.LeftShift))
            {
            activeSpeed = runSpeed;
            }

        theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * activeSpeed, theRB.velocity.y);


        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                Jump();
            canDoubleJump = true;
                anim.SetBool("isDoubleJump", false);

            }
            else
            {
                if (canDoubleJump)
                {
                    Jump();
                    canDoubleJump = false;
                    anim.SetBool("isDoubleJump", true);
                        anim.SetTrigger("doDoubleJump");

                }
            }
        }

        if (theRB.velocity.x > 0)
        {
            transform.localScale = Vector3.one;
        }
        if (theRB.velocity.x < 0)
        {
            transform.localScale =new Vector3(-1f,1f,1f);
        }
        }else
        {
            knockbackCounter -= Time.deltaTime;
            theRB.velocity = new Vector2(knowbackSpeed * -transform.localScale.x , theRB.velocity.y);
        }
        //handle animation
        anim.SetFloat("speed", Mathf.Abs(theRB.velocity.x));
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("ySpeed", theRB.velocity.y);

    }







    public void Jump ()
    {
        theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
        AudioManager.instance.PlaySFXPitched(14);


    }



    public void KnockBack()
    {
        theRB.velocity = new Vector2(0f, jumpForce * 0.5f);
        anim.SetTrigger("isKnockingback");

        knockbackCounter = knockbackLength;

    }

}
