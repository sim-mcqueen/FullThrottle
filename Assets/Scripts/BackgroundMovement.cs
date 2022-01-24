//////////////////////////////
//// Name: Andrew Dahlman-Oeth
//// Date: 1/19/22
//// Desc: Infinite background scroll
//////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    public float yConstraint = 10.4f;
    private Rigidbody2D bgRB;
    public float speed;
    private float length;
    private Vector3 startPos = new Vector3(0, 10f, 5f);
    private SpeedManager SM;

    void Start()
    {
        SM = FindObjectOfType<SpeedManager>();
        bgRB = GetComponent<Rigidbody2D>();

        speed = SM.GetSpeed() / 5; 
        bgRB.velocity = new Vector2(0, -speed);

        length = GetComponent<SpriteRenderer>().bounds.size.y;
    }


    private void Update()
    {
        //speed = SM.GetSpeed() / 5;
        //bgRB.velocity = new Vector2(0, -speed);
        if (transform.position.y < -length)
        {
            Vector3 offset = new Vector3(0, length * 2f, 0);
            transform.position = transform.position + offset;
        }
    }

    public void ChangeSpeed(float newSpeed)
    {
        newSpeed /= 5;
        bgRB.velocity = new Vector2(0, -newSpeed);
    }
/*    private void OnBecameInvisible()
    {
        transform.position = startPos;
    }*/
}
