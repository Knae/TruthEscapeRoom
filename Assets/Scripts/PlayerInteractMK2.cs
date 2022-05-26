using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractMK2 : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] public GameObject TextDisplay;
    [SerializeField] public GameObject GameDataPrefab;

    [Header("Debug")]
    [SerializeField] private Interactable rNearbyInteractables = null;

    // Start is called before the first frame update
    void Start()
    {
        //If the GameData object containing the static variables
        //does not, then instantiate one
        if (GameObject.Find ("GameData") != null)
		{
            Instantiate(GameDataPrefab);
		}
    }

    // Update is called once per frame
    //If the player has already collided with
    //an interactable called to , then keep checking
    void Update()
    {
        if(rNearbyInteractables != null)
		{
            if (Input.GetKeyDown(KeyCode.E) && rNearbyInteractables.GetIfPromptDisplayed())
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
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.gameObject.GetComponent<Interactable>() != null)
        {
            rNearbyInteractables = collision.gameObject.GetComponent<Interactable>();
            rNearbyInteractables.DisplayEPrompt();
        }
    }

	void OnTriggerExit2D(Collider2D other) // turn off
    {
        if (other.gameObject.tag == "NPC_Trigger")
        {
            TextDisplay.SetActive(false); // Turn off UI
        }
    }

	private void OnCollisionExit2D(Collision2D collision)
	{
        if (collision.gameObject.GetComponent<Interactable>() != null)
        {
            rNearbyInteractables.HidePrompt();
            rNearbyInteractables = null;
        }
    }
}
