using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public AudioPool MusicPool;
    public AudioPool SoundPool;

    [Header("Audio Clip Referencing")]
    public AudioClip ButtonDownSound;
    public AudioClip ButtonUpSound;
    public static GameManager instance;

    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            PlayerPrefs.SetFloat("Music", .4f);
            PlayerPrefs.SetFloat("Sound", 1);
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public static float ReturnThresholds(float Size, int MaxSize, int MinSize = 0, bool WrapAround = true)
    {
        for (int i = 0; i < 1; i++)
        {
            if (Size < MinSize)
            {
                if (WrapAround)
                {
                    Size = MaxSize + (MinSize + Size) + 1;
                    i = -1;
                }
                else
                {
                    Size = MinSize;
                }
                continue;
            }

            if (Size > MaxSize)
            {
                if (WrapAround)
                {
                    Size = MinSize + (Size - MaxSize) - 1;
                    i = -1;
                }
                else
                {
                    Size = MaxSize;
                }
                continue;
            }
        }
        return Size;
    }
}