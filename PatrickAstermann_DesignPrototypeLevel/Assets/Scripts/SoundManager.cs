using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //Targets Hit
    public AudioClip[] targetHit;

    //Felix's added sound
    public AudioClip [] startBell; // Sound played when start button is hit

    //Joel's Added Sounds
    //Pause
    public AudioClip pauseMenuSfx;
    //Game Over
    public AudioClip gameOverSfx;
    //Before Start
    public AudioClip beforePressStartButtonSfx;
}
