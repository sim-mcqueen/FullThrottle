using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    public int yConstraint = 10;
    private Rigidbody2D bgRB;
    private Vector2 speed = new Vector2(0, -5);

    // Start is called before the first frame update
    void Start()
    {
        bgRB = GetComponent<Rigidbody2D>();
        bgRB.velocity = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -yConstraint)
        {
            transform.position = new Vector2(0, yConstraint);
        }
    }
}
