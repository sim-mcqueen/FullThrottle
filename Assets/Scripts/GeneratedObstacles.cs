//////////////////////////////
//// Name: Melanie Baloban
//// Date: 1/20/22
//// Desc: Obstacles generate and move down the screen
//////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratedObstacles : MonoBehaviour
{
    public GameObject obstacle;
    public Color[] colors;

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
        //left and right bounds of road
        float maxRange = Random.Range(-3, 3);

        yield return new WaitForSeconds(2);

        GameObject obj = Instantiate(obstacle, new Vector3(maxRange, 9, 0), Quaternion.identity);
        Color color = colors[Random.Range(0, colors.Length)];
        obj.GetComponent<SpriteRenderer>().color = color;

        StartCoroutine(GenerateObstacle());
    }
}
