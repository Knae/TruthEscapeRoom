using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FryingPanMovement : MonoBehaviour
{
    public float fStartXPosition;
    public float fEndXPosition;

    public bool bMovingRight;

    // Start is called before the first frame update
    void Start()
    {
        fStartXPosition = gameObject.transform.position.x;
        fEndXPosition = fStartXPosition + 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x <= fStartXPosition)
        {
            bMovingRight = true;
        }
        else if (gameObject.transform.position.x >= fEndXPosition)
        {
            bMovingRight = false;
        }


        if (bMovingRight)
        {
            
        }
        else
        {

        }

    }
}
