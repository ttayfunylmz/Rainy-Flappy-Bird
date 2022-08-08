using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadAboutScene()
    {
        SceneManager.LoadScene("About");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting the Game...");
    }
}
