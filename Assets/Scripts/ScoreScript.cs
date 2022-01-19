//////////////////////////////
//// Name: Simeon McQueen
//// Date: 1/19/22
//// Desc: Keeps track of the score for the player while also increasing it on screen
//////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public float score;
    public float pointsPerSecond;
    private BackgroundMovement background;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        pointsPerSecond = 10;
        background = FindObjectOfType<BackgroundMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        pointsPerSecond = 2 * background.speed;
        Debug.Log(pointsPerSecond);
        score += (pointsPerSecond * Time.deltaTime);
        GetComponent<TextMeshProUGUI>().text = "METERS: " + (int)score;
    }
}
