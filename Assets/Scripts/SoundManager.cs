using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : MonoBehaviour
{
    public AudioSource Sound;
    public AudioSource Music;
    public AudioSource AlarmSoundManager;
    public AudioSource PhoneSoundManager;

    [Header("Audio Clips")]
    public AudioClip Click;
    public AudioClip MenuMusic;
    public AudioClip Day1Music;
    public AudioClip Day2Music;
    public AudioClip Day3Music;
    public AudioClip Day4Music;
    public AudioClip Day5Music;
    public AudioClip Alarm;
    public AudioClip AlarmOff;
    public AudioClip Bed;
    public AudioClip Stove;
    public AudioClip Door;
    public AudioClip Knock;
    public AudioClip Bang;
    public AudioClip Bang2;
    public AudioClip Thump;
    public AudioClip Yell;
    public AudioClip Yell2;
    public AudioClip Crash;
    public AudioClip Phone;
    public static SoundManager instance;

    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            if (PlayerPrefs.GetFloat("FirstTime") == 0)
            {
                PlayerPrefs.SetFloat("MusicVolume", 1);
                PlayerPrefs.SetFloat("SoundVolume", 1);
                PlayerPrefs.SetFloat("FirstTime", 1);
            }
            instance = this;
            DontDestroyOnLoad(gameObject);
            RefreshVolume();
        }
    }

    public void RefreshVolume()
    {
        Sound.volume = PlayerPrefs.GetFloat("SoundVolume");
        AlarmSoundManager.volume = PlayerPrefs.GetFloat("SoundVolume");
        PhoneSoundManager.volume = PlayerPrefs.GetFloat("SoundVolume");
        Music.volume = PlayerPrefs.GetFloat("MusicVolume");
    }
}