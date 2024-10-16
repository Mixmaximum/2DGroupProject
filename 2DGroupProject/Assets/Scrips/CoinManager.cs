using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public int coinCount;
    public TMP_Text coinText;
    public GameObject door;
    [SerializeField]
    float coinsToDoor = 3f;
    private bool doorDestroyed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = ": " + coinCount.ToString();

        if(coinCount >= coinsToDoor && !doorDestroyed)
        {
            doorDestroyed = true;
            Destroy(door);
        }
    }
}
