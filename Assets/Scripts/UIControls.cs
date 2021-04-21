using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIControls : MonoBehaviour
{
    public GameObject mainMenuUI;
   // public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;

    public static bool GameIsPause = false;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1) % 4);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
