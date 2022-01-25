using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SpeedDisplay : MonoBehaviour
{
    private TextMeshProUGUI text;
    private PlayerSpeed speed;

    private void Start()
    {
        speed = FindObjectOfType<PlayerSpeed>();
        text = GetComponent<TextMeshProUGUI>();
    }
    // Update is called once per frame
    void Update()
    {
        text.text = "KMPH: " + speed.GetSpeed();
    }
}
