using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : MonoBehaviour
{
    public AudioSource Sound;
    public AudioSource Music;

    [Header("Audio Clips")]
    public AudioClip Click;
    public AudioClip MenuMusic;
    public AudioClip Day1Music;
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
        Music.volume = PlayerPrefs.GetFloat("MusicVolume");
    }
}