using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasCan : MonoBehaviour
{
    public float gasAmount = 10f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<Gas>().AddGas(gasAmount);
            Destroy(gameObject);
        }
    }
}
