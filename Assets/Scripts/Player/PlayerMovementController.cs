﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public float movementSpeed = 1f;
    
    Rigidbody2D rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 currentPosition = rigidBody.position;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        Vector2 inputVector = new Vector2(horizontalInput, verticalInput);
        inputVector = Vector2.ClampMagnitude(inputVector, 1f); // Prevent diagonal movement to be faster than "classic" movement
        Console.Out.Write("InputVector is => " + inputVector);

        Vector2 movementVector = inputVector * movementSpeed;
        Vector2 newPosition = currentPosition + movementVector;
        
        rigidBody.MovePosition(newPosition);
    }
}