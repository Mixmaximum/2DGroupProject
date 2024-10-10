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
    bool grounded = false;
    float timer = 0;
    [SerializeField]
    float coyoteTime = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        float moveX = Input.GetAxis("Horizontal");
        Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
        velocity.x = moveX * moveSpeed;
        GetComponent<Rigidbody2D>().velocity = velocity;
        //stop the timer if grounded
        if (grounded)
        {
            timer = 0;
        }
        //coyote Time changing grounded
        if(timer > coyoteTime)
        {
            grounded = false;
        }    
        //need to find a way to know if we are on the ground
        if (Input.GetButtonDown("Jump") && grounded)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 100 * jumpSpeed));
            grounded = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            grounded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //when we leave the ground reset the timer
        if(collision.gameObject.layer == 6)
        {
            timer = 0;
            Debug.Log("Ground Touched");
        }
       
    }

}
