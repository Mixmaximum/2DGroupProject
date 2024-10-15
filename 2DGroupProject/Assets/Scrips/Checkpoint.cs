using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private FallDamage respawn;
    private BoxCollider2D checkPointCollider;

    // Start is called before the first frame update
    void Start()
    {
        checkPointCollider = GetComponent<BoxCollider2D>();
        respawn = GameObject.FindGameObjectWithTag("Respawn").GetComponent<FallDamage>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            respawn.respawnPoint = this.gameObject;
            checkPointCollider.enabled = false;
        }
    }
}
