using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    public float yConstraint = 10.4f;
    private Rigidbody2D bgRB;
    private Vector2 speed = new Vector2(0, -5);
    private Vector2 startPos = new Vector2(0, 10.4f);

    void Start()
    {
        bgRB = GetComponent<Rigidbody2D>();
        bgRB.velocity = speed;
    }

    private void OnBecameInvisible()
    {
        transform.position = startPos;
    }
}
