//////////////////////////////
//// Name: Simeon McQueen
//// Date: 1/19/22
//// Desc: Script that controllers the car
//////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float turnSpeed = 6;
    private float speed = 0;
    private Rigidbody2D rb;
    private SpeedManager SM;
    private float OrginalTurnSpeed;
    public Collider2D obstacleCollider;
    private Gas GasS;

    public AudioSource soundEffectPlayer;
    public AudioClip collisionSound;
    public AudioClip pickUpSound;
   

    private void Start()
    {
        OrginalTurnSpeed = turnSpeed;
        rb = GetComponent<Rigidbody2D>();
        SM = FindObjectOfType<SpeedManager>();
        soundEffectPlayer = GetComponent<AudioSource>();
        GasS = FindObjectOfType<Gas>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.velocity = new Vector2(-turnSpeed, 0);
            //speed -= turnSpeed;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            rb.velocity = new Vector2(turnSpeed, 0);
            //speed += turnSpeed;
        }
        //rb.velocity = new Vector2(speed, 0f);
        if (transform.position.x > 8.5)
        {
            rb.velocity = new Vector2(-turnSpeed, 0);
        }
        else if (transform.position.x < -8.5)
        {
            rb.velocity = new Vector2(turnSpeed, 0);
        }
        turnSpeed = OrginalTurnSpeed * SM.GetSpeedPercentage();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Trigger Detected " + collision.gameObject.name);
        if (collision.CompareTag("Gas"))
        {
            GasS.AddGas(100);
            soundEffectPlayer.PlayOneShot(pickUpSound, 0.7F);
        }
        else
        {
            soundEffectPlayer.PlayOneShot(collisionSound, 0.7F);
            SM.ReduceSpeed();
        }
        Destroy(collision.gameObject);
    }

}
