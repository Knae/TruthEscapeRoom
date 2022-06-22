using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // For accessing UI

public class LastDayPhoneInteraction : MonoBehaviour
{
    public GameObject Button1; // Report button
    public GameObject Button2; // Don't report button

    public bool bIsTriggering = false;

    public Image UI_Image; // UI image to fade
    public GameObject FadeToBlackObject; 
    public Color objectColor;
    public float fFadeAmount;
    public float fFadeSpeed = 0.5f;

    public bool bFading = false; // Script wont run unless this is flipped

    public GameObject EndgameText;

    // Start is called before the first frame update
    void Start()
    {
        Button1.SetActive(false);
        Button2.SetActive(false);
        objectColor = UI_Image.GetComponent<Image>().color;
        FadeToBlackObject.SetActive(false);
        EndgameText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (bIsTriggering == true)
        {
            StaticVariables.bInteractingWithObject = true; // Freezes player movement
            Button1.SetActive(true);
            Button2.SetActive(true);
        }

        if (bFading == true)
        {
            if (UI_Image.GetComponent<Image>().color.a < 1)
            {
                fFadeAmount = objectColor.a + (fFadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fFadeAmount);
                UI_Image.GetComponent<Image>().color = objectColor;
            }

            if (UI_Image.GetComponent<Image>().color.a >= 1)
            {
                EndgameText.SetActive(true);
            }
        }
    }


    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag == "Player" && StaticVariables.iDay >= 6) // Check that it is player and day is at least 6
        {
            bIsTriggering = true;
        }
    }

    // Engame buttons - what happens if pressed - does the same thing no matter the button
    public void EndGameButton()
    {
        bFading = true; // turn on fading
        FadeToBlackObject.SetActive(true);
    }
}
