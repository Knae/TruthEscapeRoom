using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPerDay : MonoBehaviour
{
    void Start()
    {
        if (StaticVariables.iDay == 1)
        {
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
