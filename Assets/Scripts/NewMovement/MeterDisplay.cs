using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MeterDisplay : MonoBehaviour
{
    public float score;
    public float pointsPerSecond;
    private SpeedDisplay kmph;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        pointsPerSecond = 10;
        kmph = FindObjectOfType<SpeedDisplay>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        pointsPerSecond = kmph.GetKMPH() / 3.6f;
        score += (pointsPerSecond * Time.deltaTime);
        GetComponent<TextMeshProUGUI>().text = "METERS: " + (int)(score * 10);
    }
}
