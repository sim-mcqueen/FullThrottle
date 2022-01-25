using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeedManager : MonoBehaviour
{
    
    public float speedIncrease;
    public int startingSpeed;
    public int middleSpeed;
    public int maxSpeed;
    public float grassBoundPos;
    public float grassBoundNeg;
    public GameObject player;
    public GameObject textGameObject;
    private BackgroundMovement[] bg;
    private ObstacleMovement[] obstacles;
    private float speed;
    private TextMeshProUGUI text;
    private bool onGrass;
    private TireParticles tireParticles;

    public AudioSource soundEffectPlayer;
    public AudioClip collisionSound;
    public AudioClip ignitionSound;
    public AudioClip doorSlamSound;

    // Start is called before the first frame update
    void Start()
    {
        tireParticles = player.transform.GetChild(0).gameObject.GetComponent<TireParticles>();
        text = textGameObject.GetComponent<TextMeshProUGUI>();
        bg = FindObjectsOfType<BackgroundMovement>();
        obstacles = FindObjectsOfType<ObstacleMovement>();
        StartCoroutine(WaitBeforeDriving());
        speedIncrease /= 100;
    }

    // Update is called once per frame
    void Update()
    {
        if(speed < 10)
        {
            if(onGrass)
            {
                speed += (speedIncrease * Time.deltaTime) / 2;
                for(int i = 0; i < obstacles.Length; i++)
                {
                    obstacles[i].ChangeSpeed(speed);
                }
                for(int i = 0; i < 2; i++)
                {
                    bg[i].ChangeSpeed(speed);
                }
                
            }
            else
            {
                speed += (speedIncrease * Time.deltaTime);
                for (int i = 0; i < 2; i++)
                {
                    bg[i].ChangeSpeed(speed);
                }
                for (int i = 0; i < obstacles.Length; i++)
                {
                    obstacles[i].ChangeSpeed(speed);
                }
            }
            text.text = "KMPH: " + (int)speed;
            speedIncrease = startingSpeed;
        }
        else if(speed < 30)
        {
            if (onGrass)
            {
                speed += (speedIncrease * Time.deltaTime) / 2;
                for (int i = 0; i < 2; i++)
                {
                    bg[i].ChangeSpeed(speed);
                }
                for (int i = 0; i < obstacles.Length; i++)
                {
                    obstacles[i].ChangeSpeed(speed);
                }
            }
            else
            {
                speed += (speedIncrease * Time.deltaTime);
                for (int i = 0; i < 2; i++)
                {
                    bg[i].ChangeSpeed(speed);
                }
                for (int i = 0; i < obstacles.Length; i++)
                {
                    obstacles[i].ChangeSpeed(speed);
                }
            }
            text.text = "KMPH: " + (int)speed;
            speedIncrease = (startingSpeed + middleSpeed) / 2;
        }
        else if(speed < 60)
        {
            if (onGrass)
            {
                
                speed += (speedIncrease * Time.deltaTime) / 2;
                for (int i = 0; i < 2; i++)
                {
                    bg[i].ChangeSpeed(speed);
                }
                for (int i = 0; i < obstacles.Length; i++)
                {
                    obstacles[i].ChangeSpeed(speed);
                }

            }
            else
            {
                speed += (speedIncrease * Time.deltaTime);
                for (int i = 0; i < 2; i++)
                {
                    bg[i].ChangeSpeed(speed);
                }
                for (int i = 0; i < obstacles.Length; i++)
                {
                    obstacles[i].ChangeSpeed(speed);
                }

            }
            text.text = "KMPH: " + (int)speed;
            speedIncrease = middleSpeed;
        }
        else if(speed < maxSpeed)
        {
            if (onGrass)
            {
                speed = 60;
                speed += (speedIncrease * Time.deltaTime) / 2;
                for (int i = 0; i < 2; i++)
                {
                    bg[i].ChangeSpeed(speed);
                }
                for (int i = 0; i < obstacles.Length; i++)
                {
                    obstacles[i].ChangeSpeed(speed);
                }
            }
            else
            {
                speed += (speedIncrease * Time.deltaTime);
                for (int i = 0; i < 2; i++)
                {
                    bg[i].ChangeSpeed(speed);
                }
                for (int i = 0; i < obstacles.Length; i++)
                {
                    obstacles[i].ChangeSpeed(speed);
                }
            }
            text.text = "KMPH: " + (int)speed;
        }
        else
        {
            if (onGrass)
            {
                speed = maxSpeed;
                for (int i = 0; i < 2; i++)
                {
                    bg[i].ChangeSpeed(speed);
                }
                for (int i = 0; i < obstacles.Length; i++)
                {
                    obstacles[i].ChangeSpeed(speed);
                }
            }
            else
            {
                speed = maxSpeed / 2;
                for (int i = 0; i < 2; i++)
                {
                    bg[i].ChangeSpeed(speed);
                }
                for (int i = 0; i < obstacles.Length; i++)
                {
                    obstacles[i].ChangeSpeed(speed);
                }
            }
            
            text.text = "KMPH: " + maxSpeed;
        }
        if(player.transform.position.x < grassBoundNeg)
        {
            if(!onGrass)
            {
                Debug.Log("on grass");
                tireParticles.UpdateTireColor(onGrass);
            }
            onGrass = true;
            
        }
        else if(player.transform.position.x > grassBoundPos)
        {
            if (!onGrass)
            {
                Debug.Log("on grass");
                tireParticles.UpdateTireColor(onGrass);
            }
            onGrass = true;
            
        }
        else
        {
            if (onGrass)
            {
                Debug.Log("off grass");
                tireParticles.UpdateTireColor(onGrass);
            }
            onGrass = false;
            
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

    IEnumerator WaitBeforeDriving()
    {
        yield return new WaitForSeconds(1);

        soundEffectPlayer.PlayOneShot(doorSlamSound, 0.7F);
        yield return new WaitForSeconds(1);

        soundEffectPlayer.PlayOneShot(ignitionSound, 0.7F);
    }
}
