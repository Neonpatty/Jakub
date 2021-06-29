using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class AnimationPlay : MonoBehaviour
{
    //VARS //all animations
    public Animator rail1; 
    public Animator rail2;
    public Animator cog1;
    public Animator cog2;
    public Animator udr1;
    public Animator udr2;
    public Animator sSign;
    public Animator nCog1;
    public Animator nCog2;
    public Animator target1000;
    public Animator targetN10001;
    public Animator targetN10002;
    public Animator target251;
    public Animator target252;

   
    //REFS
    public Timer tR; //reference to Timer Script
    
    //will start all animations in scene 
    public void PlayAni()
    {
        //if timer is running well start all the animations
        if(tR.timerRunning == true)
        {
            rail1.enabled = true;
            rail2.enabled = true;
            cog1.enabled = true;
            cog2.enabled = true;
            udr1.enabled = true;
            udr2.enabled = true;
            sSign.enabled = true;
            nCog1.enabled = true;
            nCog2.enabled = true;
            target1000.enabled = true;
            targetN10001.enabled = true;
            targetN10002.enabled = true;
            target251.enabled = true;
            target252.enabled = true;
        }
    }
}