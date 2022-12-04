using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float controlSpeed = 10f;
    [SerializeField] float xRange = 5f;
    [SerializeField] float yRange = 5f;

    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -10f;
    [SerializeField] float positionYawFactor = 2.5f;
    [SerializeField] float controlRollFactor = 5f;

    float xThrow = 0f;
    float yThrow = 0f;

    // [SerializeField] InputAction movement;
    // [SerializeField] InputAction fire;

    void Start()
    {
        
    }
   /* private void OnEnable()
    {
        movement.Enable();   
    }
    private void OnDisable()
    {
        movement.Disable();
    }*/
    void Update()
    {
        ProcessTranslation();
        ProcessRotation(); 
    }
    void ProcessTranslation()
    {
        /*float horizontalThrow = movement.ReadValue<Vector2>().x;
        Debug.Log(horizontalThrow);
        float verticalThrow = movement.ReadValue<Vector2>().y;
        Debug.Log(verticalThrow);*/

        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xOffSet = xThrow * Time.deltaTime * controlSpeed;
        float yOffSet = yThrow * Time.deltaTime * controlSpeed;


        float rawXPos = transform.localPosition.x + xOffSet;
        float rawYPos = transform.localPosition.y + yOffSet;

        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    private void ProcessRotation()
    {
        float pitch = transform.localPosition.y * positionPitchFactor + yThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor ; 
        float roll = xThrow * controlRollFactor; 

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
}
