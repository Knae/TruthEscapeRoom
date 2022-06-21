using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerInteraction : MonoBehaviour
{
    [Header("Settings")]
    public GameObject ETextDisplay;
    public bool bIsTriggering = false;
    public bool bIsUsingComputer = false;
    public float fTimePlayerMovementOff = 3.0f;
    public bool bPlayerMoving = true;
    public GameObject Player;
    public GameObject Lighting;

    // Start is called before the first frame update
    void Start()
    {
        ETextDisplay.SetActive(false);
        Lighting.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (bIsTriggering == true)
        {
            // Show E text display
            if (bIsUsingComputer == false)
            {
                ETextDisplay.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                ETextDisplay.SetActive(false);
                bPlayerMoving = false;
                Player.GetComponent<Animator>().SetBool("isInteracting", true);
                Lighting.SetActive(true);
                bIsUsingComputer = true;
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
                Lighting.SetActive(false);
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
