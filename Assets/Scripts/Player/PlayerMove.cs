using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    public float speed = 5f;
    private bool isGrounded; // define is the player is on the ground
    public float gravity = -9.8f;
    public float jumpHeight = 1.5f;

    private void Start() {
        controller = GetComponent<CharacterController>(); // take the component Character Controller from the player prefab
    }
    private void Update() {
        isGrounded = controller.isGrounded;
    }
    public void ProcessMove(Vector2 input){ 
        Vector3 moveDirection = Vector3.zero; // define vector 3
        moveDirection.x = input.x; // take the input vecto 2 and place in the vector 3 respectively from the x and z axis
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime); //move the character controller applying the vector 3 move direction
        playerVelocity.y += gravity * Time.deltaTime; //calculate the gravity
        if(isGrounded && playerVelocity.y < 0){ //evite the increment of the gravity when is in the ground
            playerVelocity.y = -1f;
        }
        controller.Move(playerVelocity * Time.deltaTime);
    }
    
    public void Jump(){
        if(isGrounded){
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }
}
