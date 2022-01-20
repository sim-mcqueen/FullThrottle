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
    public GameObject textGameObject;
    private float speed;
    private TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text = textGameObject.GetComponent<TextMeshProUGUI>();
        speedIncrease /= 100;
    }

    // Update is called once per frame
    void Update()
    {
        if(speed < 10)
        {
            speed += (speedIncrease * Time.deltaTime);
            text.text = "KMPH: " + (int)speed;
            speedIncrease = startingSpeed;
        }
        if(speed < 30)
        {
            speed += (speedIncrease * Time.deltaTime);
            text.text = "KMPH: " + (int)speed;
            speedIncrease = (startingSpeed + middleSpeed) / 2;
        }
        if(speed < 60)
        {
            speed += (speedIncrease * Time.deltaTime);
            text.text = "KMPH: " + (int)speed;
            speedIncrease = middleSpeed;
        }
        else if(speed < maxSpeed)
        {
            speed += (speedIncrease * Time.deltaTime);
            text.text = "KMPH: " + (int)speed;
        }
        else
        {
            speed = maxSpeed;
            text.text = "KMPH: " + maxSpeed;
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
