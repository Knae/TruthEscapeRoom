using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // For accessing UI

public class FadeToBlack : MonoBehaviour
{
    //public GameObject fadeObject; // GameObject to fade
    public Image UI_Image; // UI image to fade
    public Color objectColor;
    public float fFadeAmount;
    public float fFadeSpeed = 0.5f;

    public bool bFading = false; // Script wont run unless this is flipped

    public string sceneName; // Scene to transition to

    // Start is called before the first frame update
    void Start()
    {
        //fadeObject = gameObject;
        objectColor = UI_Image.GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update()
    {
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
                SceneManager.LoadScene("PlayerRoom");
            }
        }

    }
}
