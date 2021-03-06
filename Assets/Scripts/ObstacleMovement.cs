using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    private PlayerSpeed speedManager;
    public float speed;
    private Rigidbody2D obstacleRB;

    // Start is called before the first frame update
    void Start()
    {
        obstacleRB = GetComponent<Rigidbody2D>();
        speedManager = FindObjectOfType<PlayerSpeed>();
        ChangeSpeed(speedManager.GetSpeed());

    }

    void Update()
    {
        ChangeSpeed(speedManager.GetSpeed());

    }
    public void ChangeSpeed(float newSpeed)
    {
        //newSpeed /= 5;
        obstacleRB.velocity = new Vector2(0, -newSpeed);
    }
}
