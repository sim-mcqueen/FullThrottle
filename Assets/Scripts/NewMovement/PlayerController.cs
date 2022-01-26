//////////////////////////////
//// Name: Simeon McQueen
//// Date: 1/19/22
//// Desc: Script that controllers the car
//////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float turnSpeed = 4;
    private float speed = 0;
    private Rigidbody2D rb;
    private PlayerSpeed speedInstance;
    private float OrginalTurnSpeed;
    public Collider2D obstacleCollider;
    private Gas GasS;
    [SerializeField]
    private GameObject collisionPS;

    public AudioSource soundEffectPlayer;
    public AudioClip collisionSound;
    //public AudioClip ignitionSound;
    //public AudioClip doorSlamSound;

    private void Start()
    {
        OrginalTurnSpeed = turnSpeed;
        rb = GetComponent<Rigidbody2D>();
        speedInstance = FindObjectOfType<PlayerSpeed>();
        soundEffectPlayer = GetComponent<AudioSource>();
        GasS = FindObjectOfType<Gas>();

        //StartCoroutine(WaitBeforeDriving());

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.velocity = new Vector2(-turnSpeed, 0);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            rb.velocity = new Vector2(turnSpeed, 0);
        }

        if (transform.position.x > 8.5)
        {
            rb.velocity = new Vector2(-turnSpeed, 0);
        }
        else if (transform.position.x < -8.5)
        {
            rb.velocity = new Vector2(turnSpeed, 0);
        }
        turnSpeed = OrginalTurnSpeed * speedInstance.GetSpeedPercentage();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Trigger Detected " + collision.gameObject.name);
        if (collision.CompareTag("Gas"))
        {
            GasS.AddGas(100);
        }
        else
        {
            Vector2 collisionPoint = collision.ClosestPoint(transform.position);
            Instantiate(collisionPS, new Vector3(collisionPoint.x, collisionPoint.y, -5), Quaternion.identity);
            soundEffectPlayer.clip = collisionSound;
            soundEffectPlayer.Play();
            speedInstance.ReduceSpeed();
        }
        Destroy(collision.gameObject);
    }



}
