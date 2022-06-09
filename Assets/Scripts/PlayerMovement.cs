using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    Scene currentScene; 

    Rigidbody2D PlayerBody;

    float fHorizontal;
    float fVertical;

    public float fRunSpeed = 20.0f;

    void Start()
    {
        PlayerBody = GetComponent<Rigidbody2D>();
        currentScene = SceneManager.GetActiveScene(); // Get current scene and store in variable
    }

    void Update()
    {
        fHorizontal = Input.GetAxisRaw("Horizontal");
        fVertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        if (currentScene.name == "HallwayPrototypeScene") // Check if current scene is the hallway scene
        {
            PlayerBody.velocity = new Vector2(fHorizontal * fRunSpeed, fVertical * 0); // if it is, then lock vertical movement
        }
        else
        {
            PlayerBody.velocity = new Vector2(fHorizontal * fRunSpeed, fVertical * fRunSpeed); // otherwise, allow vertical movement
        }
    }
}
