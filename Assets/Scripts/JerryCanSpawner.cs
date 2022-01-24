using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JerryCanSpawner : MonoBehaviour
{
    private int SpawnNextAt;
    private ScoreScript SS;
    public GameObject JerryCan;

    // Start is called before the first frame update
    void Start()
    {
        SpawnNextAt = 140;
        SS = FindObjectOfType<ScoreScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(SS.score > SpawnNextAt)
        {
            Debug.Log("SpawnJerryCan");
            Instantiate(JerryCan, transform.position, Quaternion.identity);
            if(SS.score > 10000)
            {
                SpawnNextAt = (int)SS.score + 660;
            }
            else
            {
                SpawnNextAt = (int)((SS.score * 0.46f) + SS.score); 
            }
        }
    }
}
