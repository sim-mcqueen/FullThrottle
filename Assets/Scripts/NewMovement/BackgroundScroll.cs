//////////////////////////////
//// Name: Andrew Dahlman-Oeth
//// Date: 1/19/22
//// Desc: Infinite background scroll
//////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float multiplier = 4f;
    public float yConstraint = 10.4f;
    private Rigidbody2D bgRB;
    public float speed;
    private float length;
    private Vector3 startPos = new Vector3(0, 10f, 5f);
    private PlayerSpeed speedInstance;

    void Start()
    {
        speedInstance = FindObjectOfType<PlayerSpeed>();
        bgRB = GetComponent<Rigidbody2D>();

        speed = speedInstance.GetSpeed();
        bgRB.velocity = new Vector2(0, -speed);

        length = GetComponent<SpriteRenderer>().bounds.size.y;
    }


    private void Update()
    {
        if (transform.position.y < -length)
        {
            Vector3 offset = new Vector3(0, length * 2f, 0);
            transform.position = transform.position + offset;
        }
        ChangeSpeed(speed = speedInstance.GetSpeed());
    }

    public void ChangeSpeed(float newSpeed)
    {
        bgRB.velocity = new Vector2(0, -newSpeed * multiplier);
    }
}
