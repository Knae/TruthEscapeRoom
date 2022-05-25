using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] public GameObject TextDisplay;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

    void OnTriggerExit2D(Collider2D other) // turn off
    {
        if (other.gameObject.tag == "NPC_Trigger")
        {
            TextDisplay.SetActive(false); // Turn off UI
        }
    }
}
