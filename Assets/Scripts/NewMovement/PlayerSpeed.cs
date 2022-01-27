using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeed : MonoBehaviour
{
    private float speed;
    private float maxSpeed = 10f;
    private float speedChange = 0.5f;

    private bool onGrass;
    private float grassBoundPos = 3.37f;
    private float grassBoundNeg = -3.37f;

    private TireParticles tireParticles;
    private BackgroundMovement[] bg;

    public GameObject player;

    private void Start()
    {
        tireParticles = player.transform.GetChild(0).gameObject.GetComponent<TireParticles>();
        speed = 0.2f;
    }

    private void FixedUpdate()
    {
        if(GrassCheck())
        {
            if(speed > 10)
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

    public void Boost(int amount)
    {
        speed += amount / 10;
    }
}
