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
    public float speed = 5f;
    private Vector3 startPos = new Vector3(0, 10f, 5f);
    private SpeedManager SM;

    void Start()
    {
        SM = FindObjectOfType<SpeedManager>();
        speed = SM.GetSpeed() / 5;
        bgRB = GetComponent<Rigidbody2D>();
        bgRB.velocity = new Vector2(0, -speed);
    }


    private void Update()
    {
        speed = SM.GetSpeed() / 5;
        bgRB.velocity = new Vector2(0, -speed);
        if (transform.position.y < -10)
        {
            transform.position = startPos;
        }
    }

/*    private void OnBecameInvisible()
    {
        transform.position = startPos;
    }*/
}
