using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSec : MonoBehaviour
{

    public float time = 2;

    private void Start()
    {
        StartCoroutine(DestroyObject(gameObject));
    }
    IEnumerator DestroyObject(GameObject obj)
    { 
        yield return new WaitForSeconds(time);
        Destroy(obj);
        
    }
}
