using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Scene Numbers:    (1) Main Menu
//                  (2) Game

public class MainMenuScript : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Exitting Game");
        Application.Quit();
    }
}
