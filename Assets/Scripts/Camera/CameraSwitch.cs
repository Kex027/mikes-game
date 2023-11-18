using inputs;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Camera
{
    public class CameraSwitch : MonoBehaviour
    {
        public static CameraSwitch Instance { get; private set; }

        private Control _playerInputs;

        private int _currentCamera = 1;

        public UnityEvent OnChangedCamera;

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
            ChangeToNewCamera(1);
        }
        private void SwitchCamera2(InputAction.CallbackContext obj)
        {
            ChangeToNewCamera(2);
        }
        private void SwitchCamera3(InputAction.CallbackContext obj)
        {
            ChangeToNewCamera(3);
        }
        private void SwitchCamera4(InputAction.CallbackContext obj)
        {
            ChangeToNewCamera(4);
        }

        public int GetCurrentCamera()
        {
            return _currentCamera;
        }
        
        public void ChangeToNewCamera(int newCurrentCamera)
        {
            _currentCamera = newCurrentCamera;
            OnCamera();
        }

        private static void OnCamera()
        {
            Instance.OnChangedCamera?.Invoke();
        }
    }
}
