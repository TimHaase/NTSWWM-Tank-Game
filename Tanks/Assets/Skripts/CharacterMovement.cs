using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    public float speed;
    public float rotationSpeed;

    private CharacterController characterController;
    Vector3 moveVector;
    Vector3 turnVector;



    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        var hInput =  Input.GetAxis("Horizontal");
        var vInput = Input.GetAxis("Vertical");

        moveVector = transform.forward * speed * vInput;
        turnVector = transform.up * rotationSpeed * hInput;

        characterController.Move(moveVector * Time.deltaTime);
        transform.Rotate(turnVector * Time.deltaTime);
    }

}
