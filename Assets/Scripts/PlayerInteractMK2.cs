using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractMK2 : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] public GameObject TextDisplay;

    [Header("Debug")]
    [SerializeField] private bool bDisplayE = false;
    [SerializeField] private Interactable rNearbyInteractables = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(bDisplayE == true)
		{
            if (Input.GetKeyDown(KeyCode.E) && rNearbyInteractables!=null)
			{
                rNearbyInteractables.Interaction();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "NPC_Trigger") // Check if player triggered, and if it has already been triggered before
        {
            //if (Input.GetKeyDown(KeyCode.E)) // Check keypress for E
            //{
            TextDisplay.SetActive(true); // Turn on UI
            //}
        }
        else if( other.gameObject.GetComponent<Interactable>() !=null )
		{
            bDisplayE = true;
            rNearbyInteractables = other.gameObject.GetComponent<Interactable>();
            rNearbyInteractables.DisplayEPrompt();
        }
    }

    void OnTriggerExit2D(Collider2D other) // turn off
    {
        if (other.gameObject.tag == "NPC_Trigger")
        {
            TextDisplay.SetActive(false); // Turn off UI
        }
        else if (other.gameObject.GetComponent<Interactable>() != null)
        {
            bDisplayE = false;
            rNearbyInteractables.HidePrompt();
            rNearbyInteractables = null;
        }
    }


}
