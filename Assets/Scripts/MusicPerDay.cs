using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicPerDay : MonoBehaviour
{
    public Slider soundSlider;
    public Slider musicSlider;
    void Start()
    {
        SoundManager.instance.RefreshVolume();
        if (StaticVariables.iDay == 1)
        {
            soundSlider.normalizedValue = PlayerPrefs.GetFloat("SoundVolume");
            musicSlider.normalizedValue = PlayerPrefs.GetFloat("MusicVolume");
            SoundManager.instance.Music.clip = SoundManager.instance.Day1Music;
            SoundManager.instance.Music.Play();
        }
        else if (StaticVariables.iDay == 2)
        {
            SoundManager.instance.Music.clip = SoundManager.instance.Day2Music;
            SoundManager.instance.Music.Play();
        }
        else if (StaticVariables.iDay == 3)
        {
            SoundManager.instance.Music.clip = SoundManager.instance.Day3Music;
            SoundManager.instance.Music.Play();
        }
        else if (StaticVariables.iDay == 4)
        {
            SoundManager.instance.Music.clip = SoundManager.instance.Day4Music;
            SoundManager.instance.Music.Play();
        }
        else if (StaticVariables.iDay == 5)
        {
            SoundManager.instance.Music.clip = SoundManager.instance.Day5Music;
            SoundManager.instance.Music.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
