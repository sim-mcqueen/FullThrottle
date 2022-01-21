//////////////////////////////
//// Name: Simeon McQueen
//// Date: 1/19/22
//// Desc: Script that controllers the car
//////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float turnSpeed = 6;
    private float speed = 0;
    private Rigidbody2D rb;
    private SpeedManager SM; 
    private float OrginalTurnSpeed;

    private void Start()
    {
        OrginalTurnSpeed = turnSpeed;
        rb = GetComponent<Rigidbody2D>();
        SM = FindObjectOfType<SpeedManager>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.velocity = new Vector2(-turnSpeed, 0);
            //speed -= turnSpeed;
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            rb.velocity = new Vector2(turnSpeed, 0);
            //speed += turnSpeed;
        }
        //rb.velocity = new Vector2(speed, 0f);
        if (transform.position.x > 8.5) 
        {
            rb.velocity = new Vector2(-turnSpeed, 0);
        }
        else if(transform.position.x < -8.5)
        {
            rb.velocity = new Vector2(turnSpeed, 0);
        }
        turnSpeed = OrginalTurnSpeed * SM.GetSpeedPercentage();
    }
}
