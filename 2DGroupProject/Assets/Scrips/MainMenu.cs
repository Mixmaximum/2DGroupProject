using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    string teleportLocation = "SampleScene";
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Canvas>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Beginning()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(teleportLocation);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
