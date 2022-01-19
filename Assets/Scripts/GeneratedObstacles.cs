﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratedObstacles : MonoBehaviour
{
    public GameObject obstacle;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerateObstacle());

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator GenerateObstacle()
    {
        float maxRange = Random.Range(-7, 7);
 
        yield return new WaitForSeconds(2);
        Instantiate(obstacle, new Vector3(maxRange, 4, 0), Quaternion.identity);
        
        StartCoroutine(GenerateObstacle());
    }
}
