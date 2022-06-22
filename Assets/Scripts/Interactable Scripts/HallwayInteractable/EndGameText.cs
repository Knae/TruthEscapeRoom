using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // For accessing UI
using TMPro; // For accessing text mesh pro
using UnityEngine.SceneManagement; // Required for scene transitioning

public class EndGameText : MonoBehaviour
{
    public GameObject UI_Text;
    public TMP_Text m_TextComponent;
    public Color objectColor;

    public bool bFadingIn = false;
    public bool bFadingOut = false;

    public float fFadeAmount;
    public float fFadeSpeed = 0.5f;

    public float fTextTimer = 4.0f;

    public int iTextNumber = 0;

    public GameObject EndTextPosition;


    // Start is called before the first frame update
    void Start()
    {
        m_TextComponent = UI_Text.GetComponent<TMP_Text>();
        objectColor = m_TextComponent.color;
        bFadingIn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (bFadingIn == true)
        {
            UI_Text.SetActive(true);
            if (UI_Text.GetComponent<TMP_Text>().color.a < 1)
            {
                fFadeAmount = objectColor.a + (fFadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fFadeAmount);
                m_TextComponent.color = objectColor;
            }

            if (m_TextComponent.color.a >= 1)
            {
                //Debug.Log("TEST");
                fTextTimer = fTextTimer - 1 * Time.deltaTime;
                if (fTextTimer <= 0)
                {
                    if (iTextNumber < 5)
                    {
                        bFadingIn = false;
                        bFadingOut = true;
                        fTextTimer = 4.0f;
                    }
                }
            }
        }

        if (bFadingOut == true)
        {
            UI_Text.SetActive(true);
            if (UI_Text.GetComponent<TMP_Text>().color.a >= 0)
            {
                fFadeAmount = objectColor.a - (fFadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fFadeAmount);
                m_TextComponent.color = objectColor;
            }

            if (m_TextComponent.color.a <= 0)
            {
                iTextNumber++;
                bFadingIn = true;
                bFadingOut = false;
                //Debug.Log("iTextNumber = " + iTextNumber); // testing iTextNumber
            }
        }

        if (iTextNumber == 0)
        {
            m_TextComponent.SetText("Domestic violence can happen anywhere.");
        }
        else if (iTextNumber == 1)
        {
            m_TextComponent.SetText("The World Health Organisation (WHO) estimates that 27% of women worldwide between the ages of 15-49 has been exposed to domestic abuse by an intimate partner.");
        }
        else if (iTextNumber == 2)
        {
            m_TextComponent.SetText("The socio-economic effects of Covid-19 have only compounded this issue, with domestic violence emergency calls increasing by 20%.");
        }
        else if (iTextNumber == 3)
        {
            m_TextComponent.SetText("Less than half of domestic violence cases get reported");
        }
        else if (iTextNumber == 4)
        {
            m_TextComponent.SetText("If you suspect domestic violence, you can report this to police, or to one of the many organisations.");
        }
        else if (iTextNumber >= 5)
        {
            Debug.Log("Game Complete");
            UI_Text.transform.position = new Vector3(EndTextPosition.transform.position.x, EndTextPosition.transform.position.y, 0.0f);
            m_TextComponent.SetText("Press any key to return to main menu.");
            
            if (Input.anyKey)
            {
                SceneManager.LoadScene("Main Menu");
            }
        }

    }
}
