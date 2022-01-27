using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinOut : MonoBehaviour
{
    public bool spin;
    public float spinSpeed;
    public float moveSpeed;
    public Vector3 dir;

    void FixedUpdate()
    {
        if(spin)
        {
            dir.z = 0;
            transform.Rotate(0, 0, spinSpeed);
            transform.position = transform.position + (moveSpeed * dir);
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
