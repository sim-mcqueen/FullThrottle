//////////////////////////////
//// Name: Melanie Baloban
//// Date: 1/20/22
//// Desc: Obstacles generate and move down the screen
//////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostSpawner : MonoBehaviour
{
    public GameObject boost;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerateBoost());

    }


    IEnumerator GenerateBoost()
    {
        //left and right bounds of road
        float maxRange = Random.Range(-3, 3);
        int timeInBetweenBoost = Random.Range(3, 9);
        yield return new WaitForSeconds(timeInBetweenBoost);

        Instantiate(boost, new Vector3(maxRange, 9, 0), Quaternion.identity);

        StartCoroutine(GenerateBoost());
    }
}
