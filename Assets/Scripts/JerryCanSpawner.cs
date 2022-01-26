using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JerryCanSpawner : MonoBehaviour
{
    private int SpawnNextAt;
    private MeterDisplay meterDisplay;
    public GameObject JerryCan;

    // Start is called before the first frame update
    void Start()
    {
        SpawnNextAt = 140;
        meterDisplay = FindObjectOfType<MeterDisplay>();
    }

    // Update is called once per frame
    void Update()
    {
        if(meterDisplay.score > SpawnNextAt)
        {
            Debug.Log("SpawnJerryCan");
            Instantiate(JerryCan, transform.position, Quaternion.identity);
            if(meterDisplay.score > 2500)
            {
                SpawnNextAt = (int)meterDisplay.score + 660;
            }
            else
            {
                SpawnNextAt = (int)((meterDisplay.score * 0.52f + 50) + meterDisplay.score); 
            }
        }
    }
}
