using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeighbourDoorInteractable : MonoBehaviour
{
    public GameObject EPrompt; // Link to E to interact
    public GameObject Interaction; // Interaction object
    public GameObject Lighting2DObject; // Link to lighting object thats in the way, so can turn off

    public GameObject Player; // Link to play gameobject

    [SerializeField] private bool bInteracting = false;
    [SerializeField] private bool bInteractionComplete = false;
    [SerializeField] private bool bInsideNeighbourTrigger = false;

    // Start is called before the first frame update
    void Start()
    {
        EPrompt.SetActive(false); // Hide E notification on scene start
        Interaction.SetActive(false);  // Turn off interaction with neighbour gameobject on scene start
    }

    // Update is called once per frame
    void Update()
    {
        // Code to start the neighbour interaction
        if (bInsideNeighbourTrigger == true) // Code will only run if player inside neighbour trigger area
        {
            if (Input.GetKeyDown(KeyCode.E) && bInteracting == false)
            {
                if (StaticVariables.iDay > 1) // Can only interact with neighbour from day 2
                {
                    bInteracting = true; // To stop interacting multiple times
                    StaticVariables.iNeighbourInteractions++; // Increase interactions variable
                    Interaction.SetActive(true); // Turn on neighbour interaction
                    Lighting2DObject.SetActive(false); // Turn off centre lighting
                }
                
            }
        }

        if (bInteractionComplete == true)
        {
            Interaction.SetActive(false); // Turn on neighbour interaction
            Lighting2DObject.SetActive(true); // Turn off centre lighting
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Debug.Log("Player collided with neighbour door");
            bInsideNeighbourTrigger = true;

            if (StaticVariables.iDay > 1) // Can only interact with neighbour from day 2
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
