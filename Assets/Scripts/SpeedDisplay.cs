using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SpeedDisplay : MonoBehaviour
{
    private TextMeshProUGUI text;
    private PlayerSpeed speed;
    private float kmph;
    private void Start()
    {
        speed = FindObjectOfType<PlayerSpeed>();
        text = GetComponent<TextMeshProUGUI>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {

        float f = Mathf.Round(speed.GetSpeed() * 10.0f) * 0.001f;
        kmph = (int)(f * 1000);
        text.text = "KMPH: " + kmph;
    }

    public float GetKMPH()
    {
        return kmph;
    }

}
