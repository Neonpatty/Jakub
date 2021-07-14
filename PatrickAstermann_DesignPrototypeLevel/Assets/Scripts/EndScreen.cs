using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    //VARS
    public GameObject endGameUi; //end screen GUI
    public GameObject mainGui; //the main HUD for player
    public GameObject fpsDot; // the FPS dot in the middle of the screen
    public Text playerScore; // text for the display score in end screen GUI

    //REFS
    public GivePoints gP; //reference to GivePoints script
   
    public SoundManager sM;
    public AudioSource aS;


    //will activate end screen GUI , deactivate all othe GUI, display the players score and unlock mouse pointer
    public void EndGame()
    {
        aS.clip = sM.gameOverSfx;
        aS.Play();
        endGameUi.SetActive(true);
        mainGui.SetActive(false);
        fpsDot.SetActive(false);
        DisplayScore();
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
    }

    //will take the players end score and convert it to text
    public void DisplayScore()
    {
        playerScore.text = (gP.score.ToString());
    }

    //will reload the scene to start again
    public void RestartGame()
    {
        SceneManager.LoadScene("ShootingGallery");
        Time.timeScale = 1f;
    }

    //will take you back to the main menu
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }
}