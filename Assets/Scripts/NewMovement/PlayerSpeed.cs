using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeed : MonoBehaviour
{
    private float speed;
    private float maxSpeed = 10f;
    private float speedChange = 0.4f;

    private bool onGrass;
    private float grassBoundPos = 3.37f;
    private float grassBoundNeg = -3.37f;

    private TireParticles tireParticles;
    private BackgroundMovement[] bg;

    public GameObject player;

    public AudioSource soundEffectPlayer;
    public AudioClip ignitionSound;
    public AudioClip doorSlamSound;

    public AudioSource musicPlayer;
    public AudioClip backgroundMusic;

    private void Start()
    {
        tireParticles = player.transform.GetChild(0).gameObject.GetComponent<TireParticles>();
        speed = 0.2f;
        StartCoroutine(WaitBeforeDriving());
    }

    private void FixedUpdate()
    {
        if (speed == 0)
        {
            return;
        }

        if (GrassCheck())
        {
            if(speed > 1)
            {
                tireParticles.UpdateTireColor(true);
                speed -= (speedChange * Time.deltaTime);
            }

        }
        else
        {
            if(speed < maxSpeed)
            {
                tireParticles.UpdateTireColor(false);
                speed += (speedChange * Time.deltaTime);
            }
            if(speed > maxSpeed)
            {
                tireParticles.UpdateTireColor(false);
                speed -= (speedChange * Time.deltaTime);
            }

        }
        
    }

    public bool GrassCheck()
    {
        if (player.transform.position.x < grassBoundNeg)
        {
            return onGrass = true;
        }
        else if (player.transform.position.x > grassBoundPos)
        {
            return onGrass = true;
        }
        else
        {
            return onGrass = false;
        }
    }

    public float GetSpeed()
    {
        return speed;
    }

    public float GetSpeedPercentage()
    {
        return speed / maxSpeed;
    }

    public void ReduceSpeed()
    {
        Debug.Log("ReduceSpeed called");
        speed *= 0.3f;
    }

    public void Boost(float amount)
    {
        speed += amount / 10;
    }

    IEnumerator WaitBeforeDriving()
    {
        speed = 0;

        soundEffectPlayer.PlayOneShot(doorSlamSound, 2.3F);
        yield return new WaitForSeconds(1);
        soundEffectPlayer.clip = ignitionSound;
        soundEffectPlayer.volume = 2.3F;
        soundEffectPlayer.Play();

        yield return new WaitForSeconds(ignitionSound.length);
        StartCoroutine(PlayAudio());

        speed = 1;

    }

    IEnumerator PlayAudio()
    {
        musicPlayer.volume = 0.22F;

        musicPlayer.clip = backgroundMusic;
        musicPlayer.Play();
     
        yield return null;
    }
}
