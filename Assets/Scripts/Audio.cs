using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Audio : MonoBehaviour
{
    public AudioMixer mixer;

    private void Awake()
    {
        mixer.SetFloat("MasterVolume", PlayerPrefs.GetFloat("MasterVolume"));
    }
    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("MasterVolume", sliderValue);
        PlayerPrefs.SetFloat("MasterVolume", sliderValue);
    }
}
