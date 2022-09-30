using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator anim;
    private Rigidbody2D rb;

    public float speed;
    public float jump;

    //code for Flip
    private bool facingRight = false;
    
    

    private void Start()
    {
        //Get the component
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        float horizontal =Input.GetAxisRaw("Horizontal"); // This is How we declare writing in brackets
        float vertical = Input.GetAxisRaw("Jump");
        PlayMovementAnimation(horizontal,vertical);
        MoveCharacter(horizontal,vertical);

        KeybindsAnim(); // Keybinds
        

    }
    private void MoveCharacter(float horizontal, float vertical)
    {  
        // Horizontaly
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

        // Vertically
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("jump");
        }

        if (vertical > 0)
        {
            rb.AddForce(new Vector2( 0f, jump),ForceMode2D.Force);
        }
    }

    private void PlayMovementAnimation(float horizontal, float vertical)
    {

        anim.SetFloat("Speed",Mathf.Abs(horizontal)); // Removed Math.Abs

        Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);  // Mathf error
       }
       else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }

    private void KeybindsAnim()
    {
        //Movement A & D
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            anim.SetBool("run", true);
        }
        else
        {
            anim.SetBool("run", false);
        }

        //Crouch  

        if (Input.GetKey(KeyCode.LeftControl))
        {
            anim.SetBool("crouch", true);
        }
        else
        {
            anim.SetBool("crouch", false);
        }
    }

    // JUMP

}