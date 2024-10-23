using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallDamage : MonoBehaviour
{
    
    public GameObject respawnPoint;
    [SerializeField]
    float fatalVelocity = 1;
    Rigidbody2D rb;
    bool dead = false;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    { // Establish the player
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {// Update the y velocity float
        Vector2 velocity = rb.velocity;
        float y = velocity.y;
        //GetComponent<Rigidbody2D>().velocity = velocity;
        //Set the player to dead if they reach fatalVelocity
        if (y <= fatalVelocity)
        {
            dead = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {//If the player hits Layer 6; the ground, and are dead they go back to the checkpoint and aren't dead
        if (collision.gameObject.layer == 6)
        {
            
            if(dead)
            {
                player.transform.position = respawnPoint.transform.position;
                dead = false;
            }
        }
        if (collision.gameObject.layer == 8)
        {
            player.transform.position = respawnPoint.transform.position;
            dead = false;
        }

    }
}
