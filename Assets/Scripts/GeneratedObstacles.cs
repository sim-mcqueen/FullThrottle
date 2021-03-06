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

    private float waitTime = 2;

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(GenerateObstacle());

    }


    IEnumerator GenerateObstacle()
    {
        //left and right bounds of road
        float maxRange = Random.Range(-2.6f, 2.6f);
        float speed = FindObjectOfType<PlayerSpeed>().GetSpeed();
        if(speed <= 0)
        {
            speed = 1;
        }
        
        yield return new WaitForSeconds(waitTime / speed * 2.5f);
        GameObject obj = Instantiate(obstacle, new Vector3(maxRange, 9, 0), Quaternion.identity);
        Color color = colors[Random.Range(0, colors.Length)];
        obj.GetComponent<SpriteRenderer>().color = color;

        StartCoroutine(GenerateObstacle());
    }
}
