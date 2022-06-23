using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenu;
    public Slider soundSlider;
    public Slider musicSlider;
    public GameObject optionsMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        SoundManager.instance.Sound.PlayOneShot(SoundManager.instance.Click);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        SoundManager.instance.Sound.PlayOneShot(SoundManager.instance.Click);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Options()
    {
        SoundManager.instance.Sound.PlayOneShot(SoundManager.instance.Click);
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }
    public void Back()
    {
        SoundManager.instance.Sound.PlayOneShot(SoundManager.instance.Click);
        pauseMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void LoadMenu()
    {
        SoundManager.instance.Sound.PlayOneShot(SoundManager.instance.Click);
        Time.timeScale = 1f;
        GameIsPaused = false;
        SoundManager.instance.AlarmSoundManager.Stop();
        SoundManager.instance.PhoneSoundManager.Stop();
        SceneManager.LoadScene("Main Menu");
    }

    public void Quit()
    {
        SoundManager.instance.Sound.PlayOneShot(SoundManager.instance.Click);
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