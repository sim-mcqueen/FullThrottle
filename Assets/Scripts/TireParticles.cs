using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TireParticles : MonoBehaviour
{
    private Color defaultColor1 = new Color(0.13f, 0.13f, 0.13f);
    private Color defaultColor2 = new Color(0.35f, 0.35f, 0.35f);
    private Color grassColor = new Color(0.235f, 0.482f, 0.18f);

    private ParticleSystem.MainModule main;
    void Start()
    {
        main = gameObject.GetComponent<ParticleSystem>().main;
        main.startColor = new ParticleSystem.MinMaxGradient(defaultColor1, defaultColor2);
    }

    public void UpdateTireColor(bool onGrass)
    {
        if(onGrass)
        {
            main.startColor = new ParticleSystem.MinMaxGradient(defaultColor1, grassColor);
        }
        else
        {
            main.startColor = new ParticleSystem.MinMaxGradient(defaultColor1, defaultColor2);
        }
        
        
    }
}
