using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MakeWorldDark : MonoBehaviour
{
    public GameObject evilBG;
    public GameObject darkLight;
    public GameObject enemy;
    [SerializeField]
    float lightlevel = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        evilBG.GetComponent<SpriteRenderer>().enabled = false;
        darkLight.GetComponent<Light2D>().intensity = 1;
        enemy.GetComponent<EnemyAI>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (evilBG.GetComponent<SpriteRenderer>().enabled == false && darkLight.GetComponent<Light2D>().intensity == 1)
        {
            evilBG.GetComponent<SpriteRenderer>().enabled = true;
            darkLight.GetComponent<Light2D>().intensity = lightlevel;
            enemy.GetComponent<EnemyAI>().enabled = true;
        }
    }
}
