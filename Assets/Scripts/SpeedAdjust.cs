using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedAdjust : MonoBehaviour
{
    private float speed;
    private float min;
    private Vector3 targetPos;
    private float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        min = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        speed = FindObjectOfType<PlayerSpeed>().GetSpeedPercentage();
        targetPos = new Vector3(transform.position.x, min + speed, transform.position.y);
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
    }
}
