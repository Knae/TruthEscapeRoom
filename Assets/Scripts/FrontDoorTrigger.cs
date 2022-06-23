using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontDoorTrigger : MonoBehaviour
{

    bool bIsTriggering = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bIsTriggering == true && 
            StaticVariables.iNeighbourInteractions >= 2 && 
            StaticVariables.iDay == 5)
        {
            StaticVariables.bNeighbourInteractPlayerFrontDoor = true;
        }

        if (StaticVariables.bNeighbourInteractPlayerFrontDoor == true)
        {
            //call confrontation dialogue function
            GameObject dialogueManager = GameObject.Find("ConfrontationDialogueManager");
            dialogueManager.GetComponent<DialogueFileReader>().SetConfrontationDialogue();
        }

    }


    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag == "Player") // Check that it is player and day is at least 6
        {
            Debug.Log("Player entered trigger area for front door");
            bIsTriggering = true;
        }
    }

    void OnTriggerExit2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag == "Player") // Check that it is player and day is at least 6
        {
            Debug.Log("Player exited trigger area for front door");
        }
    }
}
