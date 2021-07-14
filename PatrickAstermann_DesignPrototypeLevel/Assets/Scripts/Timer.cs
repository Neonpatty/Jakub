using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //VARS
    public float timeRemaining = 30; //set a time for countdown
    public bool timerRunning = false; //is the time running or not
    public Text timerText; //text that displays the countdown

    //REFS
    public EndScreen eS; //reference to the End Screen Script
    public AnimationPlay aP; //reference to the Animation Play Script
                             //REFS
    public SoundManager sM;
    public AudioSource aS;

    //will change timer running to true and fire off function in Animation Play script
    public void StartGameNow()
    {
        timerRunning = true;
        aP.PlayAni();
    }

    //if timer is running will start countdown
    void Update()
    {
        if (timerRunning)
        {
            // if the time is still above 0 will keep counting down
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTimer(timeRemaining);
            }
            //if hits 0 will fire off Endgame Function in the End Screen Script
            else
            {
                Debug.Log("Time Has Run Out");
                timeRemaining = 0;
                timerRunning = false;
                eS.EndGame();
            }
        }
        else
        {
            aS.clip = sM.beforePressStartButtonSfx;
            aS.Play();
        }
    }

    //will take time and convert it  minutes, seconds and to text
    void DisplayTimer(float timeToDisplay)
    {
        timeToDisplay += 1;

        float mintues = Mathf.FloorToInt(timeToDisplay / 60); //takes the time and converts it to minutes
        float seconds = Mathf.FloorToInt(timeToDisplay % 60); //takes the time and converts it to seconds

        timerText.text = string.Format("{0:00}:{1:00}", mintues, seconds);
    }
}