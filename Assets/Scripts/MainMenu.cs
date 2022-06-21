using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public Slider soundSlider;
    public Slider musicSlider;

    public void Start()
    {
        soundSlider.value = PlayerPrefs.GetFloat("SoundVolume");
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        SoundManager.instance.Music.clip = SoundManager.instance.MenuMusic;
        SoundManager.instance.Music.Play();
    }

    // Play Button
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Loads the next scene
        SoundManager.instance.Sound.PlayOneShot(SoundManager.instance.Click);
        SoundManager.instance.Music.Stop();
        //SoundManager.instance.Music.clip = SoundManager.instance.Day1Music;
        //SoundManager.instance.Music.Play();
    }

    // Options Button
    public void Options()
    {
        SoundManager.instance.Sound.PlayOneShot(SoundManager.instance.Click);
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    // Back Button
    public void Back()
    {
        SoundManager.instance.Sound.PlayOneShot(SoundManager.instance.Click);
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    // Quit Button
    public void Quit()
    {
        Application.Quit();
    }

    public void slideSound()
    {
        PlayerPrefs.SetFloat("SoundVolume", soundSlider.value);
        SoundManager.instance.RefreshVolume();
    }

    public void slideMusic()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
        SoundManager.instance.RefreshVolume();
    }
}