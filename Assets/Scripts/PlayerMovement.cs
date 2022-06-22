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

    Animator animation;
    public bool bFacingRight = true;
    public bool bInteract = false;

    void Start()
    {
        PlayerBody = GetComponent<Rigidbody2D>();
        currentScene = SceneManager.GetActiveScene(); // Get current scene and store in variable
        animation = GetComponent<Animator>(); // Get the attached animator
    }

    void Update()
    {
        if (StaticVariables.bInteractingWithNeighbour == false && StaticVariables.bInteractingWithObject == false) // Stop movement and animations
        {
            fHorizontal = Input.GetAxisRaw("Horizontal"); // Player horizontal movement variable
            fVertical = Input.GetAxisRaw("Vertical"); // Player vertical movement variable
        }

        // --Animation--
        // Horizontal animation - flips image depending on direction
        if (fHorizontal != 0)
        {
            animation.SetBool("isWalking", true);
            animation.SetBool("isHorizontal", true);
            animation.SetBool("isVertical", false);

            if (fHorizontal > 0 && bFacingRight == false)
            {
                bFacingRight = true;
                Flip();
            }
            else if (fHorizontal < 0 && bFacingRight == true)
            {
                bFacingRight = false;
                Flip();
            }
        }
        // Vertical animation
        else if (fVertical != 0 && currentScene.name != "HallwayPrototypeScene")
        {
            animation.SetBool("isWalking", true);
            animation.SetBool("isVertical", true);
            animation.SetBool("isHorizontal", false);
        }
        else
        {
            animation.SetBool("isWalking", false);
            animation.SetBool("isVertical", false);
            animation.SetBool("isHorizontal", false);
        }

        // Double check to force character to idle if no movement
        if (StaticVariables.bInteractingWithNeighbour == true || StaticVariables.bInteractingWithObject == true)
        {
            animation.SetBool("isWalking", false);
            animation.SetBool("isVertical", false);
            animation.SetBool("isHorizontal", false);
        }
        
    }

    private void FixedUpdate()
    {
        if (currentScene.name == "HallwayPrototypeScene") // Check if current scene is the hallway scene
        {
            if (StaticVariables.bInteractingWithNeighbour == false && StaticVariables.bInteractingWithObject == false) // Stop player movement if interacting with neighbour or objects
            {
                PlayerBody.velocity = new Vector2(fHorizontal * fRunSpeed, fVertical * 0); // if it is, then lock vertical movement
            }
        }
        else if (StaticVariables.bInteractingWithObject == false)
        {
            PlayerBody.velocity = new Vector2(fHorizontal * fRunSpeed, fVertical * fRunSpeed); // otherwise, allow vertical movement
        }

        // Stop movement
        if (StaticVariables.bInteractingWithNeighbour == true || StaticVariables.bInteractingWithObject == true)
        {
            PlayerBody.velocity = new Vector2(0, 0); // otherwise, allow vertical movement
        }
    }


    void Flip()// Function to flip player sprite if moving left or right
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}