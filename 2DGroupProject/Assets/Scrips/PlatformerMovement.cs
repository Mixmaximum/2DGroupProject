using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlatformerMovement : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 5f;
    [SerializeField]
    float jumpSpeed = 2f;
    public bool grounded = false;
    float timer = 0;
    [SerializeField]
    float coyoteTime = 2;
    bool canJump = true;
    public float moveX;
    float startGrav;
    Rigidbody2D rb;
    [SerializeField]
    float maxJumpHeight;
    // Start is called before the first frame update
    void Start()
    { //Reference the rigidbody and learn the starting gravity
        rb = GetComponent<Rigidbody2D>();
        startGrav = rb.GetComponent<Rigidbody2D>().gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        //Set timer
        timer += Time.deltaTime;
        //Move X
        float moveX = Input.GetAxis("Horizontal");
        //Find velocity
        Vector2 velocity = rb.velocity;
        velocity.x = moveX * moveSpeed;
        rb.velocity = velocity;
        //coyote Time changing grounded
        if(timer > coyoteTime && !grounded)
        {
            canJump = false;
        }    
        //need to find a way to know if we are on the ground
        if (Input.GetButtonDown("Jump") && canJump)
        {
            rb.gravityScale = maxJumpHeight;
            rb.AddForce(new Vector2(0, 100 * jumpSpeed));
            grounded = false;
            canJump = false;
        }
        if(Input.GetButtonUp ("Jump"))
        {
            rb.gravityScale = startGrav;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //When colliding with the floor we want to ground and be able to jump
        if (collision.gameObject.layer == 6)
        {
            grounded = true;
            canJump = true;
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //when we leave the ground reset the timer and unground ourselves
        if(collision.gameObject.layer == 6)
        {
            timer = 0;
            grounded = false;
            Debug.Log("Left Ground");
        }
       
    }

}
