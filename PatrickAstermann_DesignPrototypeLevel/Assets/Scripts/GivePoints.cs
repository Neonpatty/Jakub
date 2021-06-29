using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GivePoints : MonoBehaviour
{
    //VARS
    public int score = 0; //intial players score
    public Text points; //text field that updates every hit
    
    //REFS
    public Timer tR; //reference to timer script

    //will add hit targets vaule to players score
    public void AwardPoints(int pValue)
    {
        if(tR.timerRunning == true)
        {
            score += pValue;
            points.text = score.ToString();
            Debug.Log("i have been hit");
        }
    }
}