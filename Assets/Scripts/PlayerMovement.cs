using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector2 = System.Numerics.Vector2;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _player;
    private PlayerInputs _playerInputs;
    
    private void Awake()
    {
        _player = GetComponent<Rigidbody>();

        _playerInputs = new PlayerInputs();
        
        _playerInputs.Enable();
        _playerInputs.Player.Move.performed += Move;
    }

    private void Move(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            // Debug.Log(context.performed);
            Debug.Log(_playerInputs.Player.Move.ReadValue<Vector2>());
            // Vector2 inputVector = context.ReadValue<Vector2>();
            // Debug.Log(inputVector);
            // _player.AddForce(new Vector3(0, 0 ,0));
        }
    }
}
