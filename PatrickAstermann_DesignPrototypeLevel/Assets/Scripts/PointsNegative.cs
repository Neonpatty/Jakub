using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsNegative : MonoBehaviour
{
    //VARS
    public GameObject floatingPoints;
    public int pValue = 0; //intial point value

    //REFS
    public GivePoints gP; //reference to give points script
    public Shooting sH; //reference to shooting script
    public Timer tI; //reference to Timer Script

    //will send hit targets value to the awardpoints function
    public void HitByRay()
    {
        gP.AwardPoints(pValue);
        ShowPoints();
    }

    public void ShowPoints()
    {
        if (tI.timerRunning)
        {
            var newObject = Instantiate(floatingPoints, transform.position, Quaternion.identity, transform);
            if (sH.hit.transform.gameObject.layer == 9)
            {
                newObject.GetComponent<TextMesh>().text = pValue.ToString();
                newObject.GetComponent<TextMesh>().color = new Color(0, 128, 0);
            }
            else if (sH.hit.transform.gameObject.layer == 12)
            {
                newObject.GetComponent<TextMesh>().text = pValue.ToString();
                newObject.GetComponent<TextMesh>().color = new Color(255, 0, 0);
            }
        }
    }
}
