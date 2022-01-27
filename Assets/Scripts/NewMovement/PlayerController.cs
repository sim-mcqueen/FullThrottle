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
    public float turnSpeed = 3;
    private float speed = 0;
    private Rigidbody2D rb;
    private PlayerSpeed speedInstance;
    private float OrginalTurnSpeed;
    public Collider2D obstacleCollider;
    private Gas GasS;
    [SerializeField]
    private GameObject collisionPS;
    private PlayerSpeed PS;

    public AudioSource soundEffectPlayer;
    public AudioClip collisionSound;
    public AudioClip pickUpSound;

    private void Start()
    {
        OrginalTurnSpeed = turnSpeed;
        rb = GetComponent<Rigidbody2D>();
        speedInstance = FindObjectOfType<PlayerSpeed>();
        soundEffectPlayer = GetComponent<AudioSource>();
        GasS = FindObjectOfType<Gas>();
        PS = FindObjectOfType<PlayerSpeed>();

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
            soundEffectPlayer.PlayOneShot(pickUpSound, 0.7F);

        }
        else if(collision.CompareTag("Boost"))
        {
            PS.Boost(5);
            soundEffectPlayer.PlayOneShot(pickUpSound, 0.7F);

            Destroy(collision);
        }
        else
        {
            Vector2 collisionPoint = collision.ClosestPoint(transform.position);
            Vector3 point = new Vector3(collisionPoint.x, collisionPoint.y, -5);
            Vector3 dir = (point - transform.position).normalized;
            Instantiate(collisionPS, point, Quaternion.identity);
            StartCoroutine(Spin(collision, dir));
            //soundEffectPlayer.clip = collisionSound;
            //soundEffectPlayer.Play();
            soundEffectPlayer.PlayOneShot(collisionSound, 0.7F);
            speedInstance.ReduceSpeed();
        }
        
        
    }

    IEnumerator Spin(Collider2D collision, Vector3 dir)
    {
        SpinOut spin = collision.GetComponent<SpinOut>();
        collision.GetComponent<BoxCollider2D>().enabled = false;
        spin.spin = true;
        spin.dir = dir;
        yield return new WaitForSeconds(3);
    }
}
