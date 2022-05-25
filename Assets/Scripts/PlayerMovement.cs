using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D PlayerBody;

    float fHorizontal;
    float fVertical;

    public float fRunSpeed = 20.0f;

    void Start()
    {
        PlayerBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        fHorizontal = Input.GetAxisRaw("Horizontal");
        fVertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        PlayerBody.velocity = new Vector2(fHorizontal * fRunSpeed, fVertical * fRunSpeed);
    }




}
