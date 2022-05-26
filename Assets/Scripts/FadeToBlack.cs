using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeToBlack : MonoBehaviour
{
    public GameObject fadeObject; // GameObject to fade
    public Color objectColor;
    public float fFadeAmount;
    public float fFadeSpeed = 0.5f;

    public bool bFading = false; // Script wont run unless this is flipped

    public string sceneName; // Scene to transition to

    // Start is called before the first frame update
    void Start()
    {
        fadeObject = gameObject;
        objectColor = fadeObject.GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if (bFading == true)
        {
            if (fadeObject.GetComponent<SpriteRenderer>().color.a < 1)
            {
                fFadeAmount = objectColor.a + (fFadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fFadeAmount);
                fadeObject.GetComponent<SpriteRenderer>().color = objectColor;
            }

            if (fadeObject.GetComponent<SpriteRenderer>().color.a >= 1)
            {
                SceneManager.LoadScene("SingTest");
            }
        }

    }
}
