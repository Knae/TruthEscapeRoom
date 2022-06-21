using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeighbourDoorInteractable : MonoBehaviour
{
    public GameObject EPrompt; // Link to E to interact
    public GameObject Interaction; // Interaction object
    public GameObject Lighting2DObject; // Link to lighting object thats in the way, so can turn off

    public GameObject Player; // Link to play gameobject
    [HideInInspector] Animator animation;

    [SerializeField] private bool bInteracting = false; // So that neighbour door can only be interacted once per day
    [SerializeField] private bool bInsideNeighbourTrigger = false;

    // Timer - Waits fMaxtime before starting the interaction
    [Header("Timer Related")]
    public float fMaxTime = 3.0f;
    [SerializeField] private bool bTimerStarted = false;
    [SerializeField] private bool bTimerComplete = false;
    [SerializeField] private float fTimer = 0.0f; 

    // Start is called before the first frame update
    void Start()
    {
        EPrompt.SetActive(false); // Hide E notification on scene start
        Interaction.SetActive(false);  // Turn off interaction with neighbour gameobject on scene start
        animation = Player.GetComponent<Animator>(); // Get the attached animator
    }

    // Update is called once per frame
    void Update()
    {
        if (StaticVariables.bNeighbourInteractionComplete == false)
        {
            // Code to start the neighbour interaction
            if (bInsideNeighbourTrigger == true) // Code will only run if player inside neighbour trigger area
            {
                if (Input.GetKeyDown(KeyCode.E) && bInteracting == false)
                {
                    bTimerStarted = true;
                    EPrompt.SetActive(false);
                    animation.SetBool("isInteracting", true);
                }

                if (Input.GetKeyUp(KeyCode.E)) // Forces isInteraction bool to false when key released, so interact animation runs once
                {
                    animation.SetBool("isInteracting", false);
                }
            }

            // Timer
            if (bTimerStarted == true)
            {
                fTimer = fTimer + 1 * Time.deltaTime; // Increase timer
                if (fTimer >= fMaxTime)
                {
                    bTimerStarted = false;
                    bTimerComplete = true;
                }
            }

            // -- Start Neighbour Interaction --
            if (StaticVariables.iDay > 1 && bTimerComplete == true) // Can only interact with neighbour from day 2, & waits for timer to end so shows interact animation
            {
                bInteracting = true; // To stop interacting multiple times
                StaticVariables.iNeighbourInteractions++; // Increase interactions variable
                StaticVariables.bInteractingWithNeighbour = true; // Bool used to stop player movement
                Interaction.SetActive(true); // Turn on neighbour interaction
                Lighting2DObject.SetActive(false); // Turn off centre lighting
            }
        }
        else // -- End Neighbour Interaction --
        {
            Interaction.SetActive(false); // Turn on neighbour interaction
            Lighting2DObject.SetActive(true); // Turn on centre lighting
            StaticVariables.bInteractingWithNeighbour = false; // Set static variable bool to false
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Debug.Log("Player collided with neighbour door");
            bInsideNeighbourTrigger = true;

            if (StaticVariables.iDay > 1 && StaticVariables.bNeighbourInteractionComplete == false) // Can only interact with neighbour from day 2, and if interact hasnt already happened
            {
                EPrompt.SetActive(true); // Show E notification
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            bInsideNeighbourTrigger = false;

            Debug.Log("Player left collision with neighbour door");
            EPrompt.SetActive(false); // Hide E notification
        }
    }
}
