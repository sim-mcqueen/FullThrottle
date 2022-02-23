using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Audio : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider slider;
    private bool sliderInitialized;

    private void Start()
    {
        mixer.SetFloat("MasterVolume", PlayerPrefs.GetFloat("MasterVolume"));
    }

    public void InitSlider() {
        // initializer slider only once
        if (sliderInitialized)
            return;

        slider.value = PlayerPrefs.GetFloat("MasterVolume");
        slider.onValueChanged.AddListener(SetLevel);
        sliderInitialized = true;
    }

    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("MasterVolume", sliderValue);
        PlayerPrefs.SetFloat("MasterVolume", sliderValue);
    }
}
