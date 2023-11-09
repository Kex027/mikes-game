using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Composites;
using dupa;
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _player;
    private Control _playerInputs;
    
    private void Awake()
    {
        _player = GetComponent<Rigidbody>();

        _playerInputs = new Control();
    }

    private void OnEnable()
    {
        _playerInputs.Enable();
        _playerInputs.player.move.performed += MoveOnPerformed;
    }
    private void OnDisable()
    {
        _playerInputs.Disable();
        _playerInputs.player.move.performed -= MoveOnPerformed;
    }
    private void MoveOnPerformed(InputAction.CallbackContext obj)
    {
        Debug.Log(obj.ReadValue<Vector2>());
        //Debug.Log(_playerInputs.Player.Move.);
        //Vector2 move = _playerInputs.Player.Move.ReadValue<Vector2>();
        //_player.velocity = new Vector3(move.X, 0, move.Y);
    }
}
