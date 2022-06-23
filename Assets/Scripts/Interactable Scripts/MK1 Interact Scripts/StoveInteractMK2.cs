using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveInteractMK2 : MonoBehaviour
{
    [Header("Settings")]
    public GameObject ETextDisplay;
    public bool bIsTriggering = false;
    public float fTimePlayerMovementOff = 3.0f;
    public bool bPlayerMoving = true;
    public GameObject Player;
    public GameObject FryingPan;
    public GameObject Particles;

    private bool soundPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        ETextDisplay.SetActive(false);
        FryingPan.SetActive(false);
        Particles.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (bIsTriggering == true)
        {
            // Show E text display
            if (StaticVariables.bHadBreakfast == false)
            {
                ETextDisplay.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                //call function for neighbour sound text to play from dialogue manager
                GameObject dialogueManager = GameObject.Find("NeighbourSoundsDialogue");
                dialogueManager.GetComponent<DialogueFileReader>().SetNeighbourNextDoorSoundsStart();

                ETextDisplay.SetActive(false);
                StaticVariables.bHadBreakfast = true;
                bPlayerMoving = false;
                Player.GetComponent<Animator>().SetBool("isInteracting", true);
                FryingPan.SetActive(true);
                Particles.SetActive(true);
                if (soundPlayed == false)
                {
                    SoundManager.instance.Sound.PlayOneShot(SoundManager.instance.Stove);
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
                FryingPan.SetActive(false);
                Particles.SetActive(false);
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
