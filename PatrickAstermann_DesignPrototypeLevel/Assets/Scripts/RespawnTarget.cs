using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnTarget : MonoBehaviour
{
    //VARS
    public GameObject targetR;
    public int timeToRespawn = 5;

    //REFS
    public Timer tI;

    public void HideTarget()
    {
            if(tI.timerRunning)
            {
                StartCoroutine(Wait(timeToRespawn));               
            }
    }
    
    private IEnumerator Wait(int waitTime)
    {
        yield return new WaitForSeconds(1);
        targetR.SetActive(false);
        yield return new WaitForSeconds(waitTime);
        targetR.SetActive(true);
    }
}