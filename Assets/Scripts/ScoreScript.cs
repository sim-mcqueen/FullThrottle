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
    private SpeedManager SM;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        pointsPerSecond = 10;
        SM = FindObjectOfType<SpeedManager>();
    }

    // Update is called once per frame
    void Update()
    {
        pointsPerSecond = (SM.GetSpeed() / 3.6f);
        score += (pointsPerSecond * Time.deltaTime);
        GetComponent<TextMeshProUGUI>().text = "METERS: " + (int)score;
    }
}
