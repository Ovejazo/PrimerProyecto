using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FPSController : MonoBehaviour
{
    //Inicializamos las variables
    CharacterController characterController;

    public float walkSpeed = 5.0f;
    public float runSpeed = 10.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20f;

    //Inicializamos el movimiento  
    public Vector3 move = Vector3.zero;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {   
        //Si el personaje esta en el suelo
        if (characterController.isGrounded)
        {
            move = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

            //Si el personaje corre
            if (Input.GetKey(KeyCode.LeftShift))
                move = transform.TransformDirection(move) * runSpeed;
            else
                move = transform.TransformDirection(move) * walkSpeed;

            //Si el personaje salta
            if (Input.GetKey(KeyCode.Space))
            {
                move.y = jumpSpeed;
            }
        }        

        //Aplicamos la gravedad
        move.y -= gravity * Time.deltaTime;

        characterController.Move(move * Time.deltaTime);
             
    }
}
