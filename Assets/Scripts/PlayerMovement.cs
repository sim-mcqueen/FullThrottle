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
    public float turnSpeed = 0;
    private float speed = 0;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            speed += turnSpeed;
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            speed += turnSpeed;
        }
        rb.velocity = new Vector2(speed, 0f);
    }
}
