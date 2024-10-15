using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private FallDamage respawn;
    private BoxCollider2D checkPointCollider;

    // Start is called before the first frame update
    void Start()
    { //Finds the collider on the checkpoint
        checkPointCollider = GetComponent<BoxCollider2D>();
        //Sets respawnpoint and takes the code from FallDamage script to do so
        respawn = GameObject.FindGameObjectWithTag("Player").GetComponent<FallDamage>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    { //if the player enters this object it changes respawnPoint to this object and turns off the collider
        if (other.gameObject.CompareTag("Player"))
        {
            respawn.respawnPoint = this.gameObject;
            checkPointCollider.enabled = false;
        }
    }
}
