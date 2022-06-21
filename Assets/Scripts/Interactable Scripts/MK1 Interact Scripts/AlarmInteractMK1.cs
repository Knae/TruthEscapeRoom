using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmInteractMK1 : MonoBehaviour
{
    [Header("Settings")]
    public GameObject ETextDisplay;
    public bool bIsTriggering = false;
    public float fTimePlayerMovementOff = 1.5f;
    public bool bPlayerMoving = true;
    public GameObject Player;

    [Header("Text SFX Variables")]
    [SerializeField] private GameObject objAlarmSfx;
    [SerializeField] private float fCount = 0.0f;
    [SerializeField] private const float kfDisplayFXPeriod = 2.0f;
    [SerializeField] private const float kfHideFXPeriod = -0.5f;

    private bool soundPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        ETextDisplay.SetActive(false);
        objAlarmSfx.SetActive(true);
        fCount = kfDisplayFXPeriod;
        SoundManager.instance.AlarmSoundManager.clip = SoundManager.instance.Alarm;
        SoundManager.instance.AlarmSoundManager.Play();
    }

    // Update is called once per frame
    void Update()
    {
        fCount -= Time.deltaTime;
        if (StaticVariables.bAlarmOff == false)
        {
            if (fCount <= kfDisplayFXPeriod && fCount > 0.0f)
            {
                objAlarmSfx.SetActive(true);
            }
            else if (fCount <= 0 && fCount > kfHideFXPeriod)
            {
                objAlarmSfx.SetActive(false);
            }
            else if (fCount <= kfHideFXPeriod)
            {
                fCount = kfDisplayFXPeriod;
            }
        }
        else if (StaticVariables.bAlarmOff) // If alarm is turned off
        {
            objAlarmSfx.SetActive(false);
            fCount = 0;
        }

        if (bIsTriggering == true)
        {
            // Show E text display
            if (StaticVariables.bAlarmOff == false)
            {
                ETextDisplay.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                ETextDisplay.SetActive(false);
                StaticVariables.bAlarmOff = true;
                bPlayerMoving = false;
                Player.GetComponent<Animator>().SetBool("isInteracting", true);
                SoundManager.instance.AlarmSoundManager.Stop();
                if (soundPlayed == false)
                {
                    SoundManager.instance.Sound.PlayOneShot(SoundManager.instance.AlarmOff);
                    soundPlayed = true;
                }
            }

            if (Input.GetKeyUp(KeyCode.E))
            {
                Player.GetComponent<Animator>().SetBool("isInteracting", false);
            }
        }
        else
        {
            ETextDisplay.SetActive(false);
        }

        // Stop player movement for 'fTimePlayerMovementOff' amount of time
        if (bPlayerMoving == false)
        {
            StaticVariables.bInteractingWithObject = true;
            fTimePlayerMovementOff = fTimePlayerMovementOff - 1 * Time.deltaTime;
            if (fTimePlayerMovementOff <= 0)
            {
                StaticVariables.bInteractingWithObject = false;
                bPlayerMoving = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag == "Player") // Check that it is player
        {
            bIsTriggering = true;
        }
    }

    void OnTriggerExit2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag == "Player") // Check that it is player
        {
            bIsTriggering = false;
        }
    }
}

