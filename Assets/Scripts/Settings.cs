using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    public AudioMixer audioMixer;
    public void SetMusicVolume (float MusicVolume)
    {
        audioMixer.SetFloat("MusicVolume", MusicVolume);
    }

    public void SetSoundVolume(float SoundVolume)
    {
        audioMixer.SetFloat("SoundVolume", SoundVolume);
    }
}
