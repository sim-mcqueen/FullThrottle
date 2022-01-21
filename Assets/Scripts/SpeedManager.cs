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
    // Start is called before the first frame update
    void Start()
    {
        text = textGameObject.GetComponent<TextMeshProUGUI>();
        bg = FindObjectsOfType<BackgroundMovement>();
        obstacles = FindObjectsOfType<ObstacleMovement>();
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
            onGrass = true;
            Debug.Log("on grass");
        }
        else if(player.transform.position.x > grassBoundPos)
        {
            onGrass = true;
            Debug.Log("on grass");
        }
        else
        {
            onGrass = false;
            Debug.Log("off grass");
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
}
