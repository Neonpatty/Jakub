using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //will load the next scene in the build
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //will exit the application
    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}