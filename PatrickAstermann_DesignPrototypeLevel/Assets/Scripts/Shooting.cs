using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    //VARS
    public float fireRate; //set the fire rate for shooting
    public KeyCode sKey; //set key for input
    public Camera fpsCam; //the charaters FPS camera
    public AudioSource gunShot; // audio source for gun fire
    public AudioSource gunCock; // audio source for gun reload
    public GameObject pHit; //object that the raycast hits
    public RaycastHit hit; //Information from the raycast
    public AudioSource bS; // Audio Source from the booth
    public AudioSource pS;  // Audio Source from the Player
    public AudioSource bR; //Audio Source for The Gold Target Bell Ring
    public AudioSource gameMusic; // Audio Source for the Start Bell & Game Music

    private float nextTimeFire = 0f; //locked variable for fire rate

    //REFS
    public PauseMenu pM; //reference to the Pause Menu Script
    public SoundManager sM; //reference to Sound Manager Script

    //if the game is not paused and last time fired is 0 will fire a raycast and play audio for gunshot
    void Update()
    {
        if (pM.gameIsPaused == false)
        {
            if (nextTimeFire <= Time.time)
            {
                if (Input.GetKeyDown(sKey))
                {
                    Shoot();
                    gunShot.Play();
                    gunCock.PlayDelayed(0.5f);
                    nextTimeFire = Time.time + fireRate;
                }
            }
        }
    }

    //this fires a raycast every time the the inout key is hit and gets back information from hit object
    void Shoot()
    {
        
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, 1000))
        {
            Debug.Log(hit.transform.name);
            //if the raycast hits an object with layer 9 if will play a audio cue and send a message to another script to fire that off
            if (hit.transform.gameObject.layer == 9)
            {
                bS.clip = sM.targetHit[Random.Range(0, sM.targetHit.Length)];
                bS.Play();
                hit.transform.SendMessage("HitByRay");
            }
            else if (hit.transform.gameObject.layer == 13)
            {
                bS.clip = sM.targetHit[Random.Range(0, sM.targetHit.Length)];
                bR.clip = sM.goldBellRing;
                bR.PlayDelayed(0.5f);
                bS.Play();
                hit.transform.SendMessage("HitByRay");
            }
            else if(hit.transform.gameObject.layer == 12)
            {
                bS.clip = sM.negativeHit;
                bS.Play();
                hit.transform.SendMessage("HitByRay");
            }
            //if the raycast hits an object with layer 10 it will send a message to another script to fire that off
            else if (hit.transform.gameObject.layer == 10)
            {
                gameMusic.Play();
                hit.transform.SendMessage("StartGameNow");
            }
            else if (hit.transform.gameObject.layer == 11)
            {
                bS.clip = sM.boothHit[Random.Range(0, sM.boothHit.Length)];
                bS.Play();
            }
            else if (hit.transform.gameObject.layer == 8)
            {
                bS.clip = sM.groundHit[Random.Range(0, sM.groundHit.Length)];
                bS.Play();
            }

            //everytime a raycast hits an object it will create an particle effect out from the point of impact the destory the object 2 seconds later
            GameObject impactGo = Instantiate(pHit, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGo, 2f);
        }
    }
}