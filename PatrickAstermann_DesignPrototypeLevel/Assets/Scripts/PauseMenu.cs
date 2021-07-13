using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    //VARS
    public bool gameIsPaused = false; //to state if the game is paused or not
    public KeyCode pKey; //a key you can set in inspector
    public GameObject pauseMenuUI; // pause menu GUI
    public GameObject menu;
    public GameObject optionsMenu;

    //REFS
    public SoundManager sM;
    public AudioSource aS;

    //if key is hit will open pause menu, if escape hit again will return to game
    void Update()
    {
        if (Input.GetKeyDown(pKey))
        {
            aS.clip = sM.pauseMenuSfx;
            aS.Play();
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    
    //if key is hit will close Pause Menu GUI and set game time to stantard time and lock mouse pointer to middle of screen
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    //if key is hit will bring up Pause Menu GUI, will freeze game time and unlock the mouse point
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;       
    }
    public void OptionsMenu()
    {
        menu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void BackButton()
    {
        menu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    //will load the main menu scene
    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

    //will quit the application
    public void QuitGame()
    {
        Debug.Log("Quiting Game...");
        Application.Quit();
    }
}