using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // For accessing UI
using TMPro;

public class FadeFromBlack : MonoBehaviour
{
    //public GameObject fadeObject; // GameObject to fade
    public Color objectColor;
    //public Text UI_textDay; // UI text to fade
    public TextMeshProUGUI TMPro_Text; // Text Mesh pro object
    public Image UI_Image;

    //[SerializeField] GameObject staticVariableObject; // Object holding script for static variables
    
    public float fFadeAmount;
    public float fFadeAmountText;
    public float fFadeSpeed = 0.4f;
    public float fPreFadeTimer = 2.0f;

    public bool bFading = false; // Script wont run unless this is flipped

    void Start()
    {
        UI_Image.enabled = true;
        //fadeObject = gameObject;
        objectColor = UI_Image.GetComponent<Image>().color;

        TMPro_Text.text = "Day " + StaticVariables.iDay;
    }

    void Update()
    {
        fPreFadeTimer = fPreFadeTimer - 1 * Time.deltaTime;
        if (fPreFadeTimer <= 0)
        {
            bFading = true;
        }

        if (bFading == true)
        {
            if (UI_Image.GetComponent<Image>().color.a > 0)
            {
                fFadeAmount = objectColor.a - (fFadeSpeed * Time.deltaTime);
                fFadeAmountText = fFadeAmount - 2;

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fFadeAmount);
                UI_Image.GetComponent<Image>().color = objectColor;

                TMPro_Text.color = new Color(TMPro_Text.color.r, TMPro_Text.color.g, TMPro_Text.color.b, fFadeAmountText);
            }
        }
    }
}
