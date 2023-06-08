using System.Threading;
using System.Runtime.InteropServices.ComTypes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour // control all the movement of the player
{
    //define all the parameters that is use in the script
    private PlayerInput playerInput;
    private InputAction jump;
    public InputAction interact;
    public InputAction shoot;
    public InputAction reload;
    private Vector2 input;
    private Vector2 camInput;
    private PlayerMove move;
    private PlayerCamera look;

    private void Awake() {     
        playerInput = GetComponent<PlayerInput>(); // define the player input system that take the inputs of the controller
        jump = playerInput.actions["Jump"]; // take the player input action Jump into a parameter
        interact = playerInput.actions["Interact"];
        shoot = playerInput.actions["Shoot"];
        reload = playerInput.actions["Reload"];
        move = GetComponent<PlayerMove>(); // call the script who implements the movement of the player
        look = GetComponent<PlayerCamera>(); // call the script who implements the movement of the camera
        jump.performed += ContextCallback => move.Jump(); // subscribe to the function jump in the move script
    }
    private void Update() {
        input = playerInput.actions["Movement"].ReadValue<Vector2>(); // take the input controller of movement and transform into a vector 2
        camInput = playerInput.actions["Camera"].ReadValue<Vector2>();     
    }
    private void FixedUpdate() {
        move.ProcessMove(input); //player move function
    }
    private void LateUpdate() {
        look.ProcessLook(camInput); //player move camera function
    }
}
