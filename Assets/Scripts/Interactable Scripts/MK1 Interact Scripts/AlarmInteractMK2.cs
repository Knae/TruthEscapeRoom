using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmInteractMK1 : MonoBehaviour
{
    [Header("Settings")]
    public GameObject ETextDisplay;
    public bool bIsTriggering = false;

    [Header("DebugVariables")]
    [SerializeField] private GameObject objAlarmSfx;
    [SerializeField] private float fCount = 0.0f;
    [SerializeField] private const float kfDisplayFXPeriod = 2.0f;
    [SerializeField] private const float kfHideFXPeriod = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        ETextDisplay.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        fCount -= Time.deltaTime;
        if (fCount <= 0 && !StaticVariables.bAlarmOff)
        {
            if (objAlarmSfx == null)
            {
                objAlarmSfx.transform.position = transform.position;
                fCount = kfDisplayFXPeriod;
            }
            else
            {
                Destroy(objAlarmSfx);
                objAlarmSfx = null;
                fCount = kfHideFXPeriod;
            }
        }
        else if (objAlarmSfx != null & StaticVariables.bAlarmOff)
        {
            Destroy(objAlarmSfx);
            objAlarmSfx = null;
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
            }
        }
        else
        {
            ETextDisplay.SetActive(false);
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
