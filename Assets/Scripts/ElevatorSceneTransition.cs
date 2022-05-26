using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorSceneTransition : MonoBehaviour
{
    public GameObject fadeToBlackObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Debug.Log("Player entered elevator trigger");
            fadeToBlackObject.GetComponent<FadeToBlack>().bFading = true; // Turn on fade to black object

            //SceneManager.LoadScene(sceneName);
        }
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag.Equals("Player"))
    //    {
    //
    //        if (Input.GetKeyDown(KeyCode.E))
    //        {
    //            Debug.Log("Player pressed E for elevator");
    //
    //        }
    //
    //        //SceneManager.LoadScene(sceneName);
    //    }
    //}

    
}
