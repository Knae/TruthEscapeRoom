using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // For accessing UI

public class FadeFromBlack : MonoBehaviour
{
    public GameObject fadeObject; // GameObject to fade
    public Color objectColor;
    public Text UI_textDay; // UI text to fade
    [SerializeField] GameObject staticVariableObject; // Object holding script for static variables
    
    public float fFadeAmount;
    public float fFadeAmountText;
    public float fFadeSpeed = 0.4f;
    public float fPreFadeTimer = 2.0f;

    public bool bFading = false; // Script wont run unless this is flipped

    void Start()
    {
        fadeObject = gameObject;
        objectColor = fadeObject.GetComponent<SpriteRenderer>().color;

        
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
            if (fadeObject.GetComponent<SpriteRenderer>().color.a > 0)
            {
                fFadeAmount = objectColor.a - (fFadeSpeed * Time.deltaTime);
                fFadeAmountText = fFadeAmount - 2;

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fFadeAmount);
                fadeObject.GetComponent<SpriteRenderer>().color = objectColor;

                UI_textDay.color = new Color(UI_textDay.color.r, UI_textDay.color.g, UI_textDay.color.b, fFadeAmountText);
            }
        }
    }
}
