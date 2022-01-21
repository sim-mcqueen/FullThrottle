﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    private SpeedManager speedManager;
    public float speed;
    public Rigidbody2D clone;
    private Rigidbody2D obstacleRB;

    // Start is called before the first frame update
    void Start()
    {
        obstacleRB = GetComponent<Rigidbody2D>();
        speedManager = FindObjectOfType<SpeedManager>();

    }

    // Update is called once per frame
    void Update()
    {
        speed = speedManager.GetSpeed() / 5;
        obstacleRB.velocity = new Vector2(0, -speed);
    }
}