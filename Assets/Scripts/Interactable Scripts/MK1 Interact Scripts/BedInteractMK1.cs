using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedInteractMK1 : MonoBehaviour
{
    [Header("Bed Textures")]
    public GameObject Bed_Made;
    public GameObject Bed_NotMade;

    [Header("Settings")]
    public GameObject ETextDisplay;
    public bool bIsTriggering = false;


    // Start is called before the first frame update
    void Start()
    {
        ETextDisplay.SetActive(false);
        Bed_Made.SetActive(false);
        Bed_NotMade.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (bIsTriggering == true)
        {
            // Show E text display
            if (StaticVariables.bMadeBed == false)
            {
                ETextDisplay.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                ETextDisplay.SetActive(false);
                Bed_Made.SetActive(true);
                Bed_NotMade.SetActive(false);
                StaticVariables.bMadeBed = true;
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
