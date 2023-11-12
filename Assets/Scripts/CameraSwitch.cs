using System;
using System.Collections;
using System.Collections.Generic;
using inputs;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using Vector2 = System.Numerics.Vector2;

public class CameraSwitch : MonoBehaviour
{
    public static CameraSwitch Instance { get; private set; }

    private Control _playerInputs;

    private int currentCamera = 1;

    private void Awake() 
    {
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this;
        }
        _playerInputs = new Control();
        
        _playerInputs.player.switchcamera1.performed += SwitchCamera1;
        _playerInputs.player.switchcamera2.performed += SwitchCamera2;
        _playerInputs.player.switchcamera3.performed += SwitchCamera3;
        _playerInputs.player.switchcamera4.performed += SwitchCamera4;
    }

    private void OnEnable()
    {
        _playerInputs.Enable();
    }

    private void OnDisable()
    {
        _playerInputs.Disable();
    }

    private void SwitchCamera1(InputAction.CallbackContext obj)
    {
        currentCamera = 1;
    }
    private void SwitchCamera2(InputAction.CallbackContext obj)
    {
        currentCamera = 2;
    }
    private void SwitchCamera3(InputAction.CallbackContext obj)
    {
        currentCamera = 3;
    }
    private void SwitchCamera4(InputAction.CallbackContext obj)
    {
        currentCamera = 4;
    }

    public int GetCurrentCamera()
    {
        return currentCamera;
    }
}
