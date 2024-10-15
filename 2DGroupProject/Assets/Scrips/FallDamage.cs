using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallDamage : MonoBehaviour
{
    public GameObject player;
    public GameObject respawnPoint;
    [SerializeField]
    float fatalVelocity = 1;
    Rigidbody2D rb;
    bool dead = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 velocity = rb.velocity;
        float y = velocity.y;
        //GetComponent<Rigidbody2D>().velocity = velocity;
        
        if (y <= fatalVelocity)
        {
            dead = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            
            if(dead)
            {
                player.transform.position = respawnPoint.transform.position;
                dead = false;
            }
        }
    }
}
