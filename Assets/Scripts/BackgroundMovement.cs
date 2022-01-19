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
    private Vector2 startPos = new Vector2(0, 10.4f);

    void Start()
    {
        bgRB = GetComponent<Rigidbody2D>();
        bgRB.velocity = new Vector2(0, -speed);
    }

    private void OnBecameInvisible()
    {
        transform.position = startPos;
    }
}
