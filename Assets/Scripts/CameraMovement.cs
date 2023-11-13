using System;
using UnityEngine;
using inputs;

public class CameraMovement : MonoBehaviour
{
    private CapsuleCollider _player;
    [SerializeField] private Transform direction;
    private Control _playerInputs;
    
    [SerializeField] private GameObject[] cameraSpots;
    private float _xRotation = 0;
    private float _yRotation = 0;
    private float _sensitivityX = 0.5f;
    private float _sensitivityY = 0.5f;
    private Vector3 _firstPersonCameraPosition;

    private void Awake()
    {
        _player = GetComponentInParent<CapsuleCollider>();
        _playerInputs = new Control();
        _firstPersonCameraPosition = new Vector3(transform.localPosition.x, _player.height / 2 * 0.75f, transform.localPosition.z);
    }

    private void Start()
    {
        transform.position = _firstPersonCameraPosition;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void FixedUpdate()
    {
        HandleCameraPosition();
    }

    private void Update()
    {
        RotateCameraAndPlayer();
    }

    private void OnEnable()
    {
        _playerInputs.Enable();
    }
    private void OnDisable()
    {
        _playerInputs.Disable();
    }

    private void HandleCameraPosition()
        //to nie moze byc w updacie bo jest W HUJ NIEOPTYMALNE, robisz ze w tych eventach w camera switch !!!!! wykonuje sie raz na klik a nie 1 na klatke
    {
        switch (CameraSwitch.Instance.GetCurrentCamera())
        {
            case 1:
                transform.SetParent(cameraSpots[0].transform, false);
                transform.localPosition = _firstPersonCameraPosition;
                break;
            case 2:
                transform.SetParent(cameraSpots[1].transform, false);
                transform.localPosition = Vector3.zero;
                transform.localEulerAngles = Vector3.zero;
                break;
            case 3:
                transform.SetParent(cameraSpots[2].transform, false);
                transform.localPosition = Vector3.zero;
                transform.localEulerAngles = Vector3.zero;
                break;
            case 4:
                transform.SetParent(cameraSpots[3].transform, false);
                transform.localPosition = Vector3.zero;
                transform.localEulerAngles = Vector3.zero;
                break;
            default:
                transform.SetParent(cameraSpots[0].transform, false);
                break;
        }
    }

    private void RotateCameraAndPlayer()
    {
        Vector2 mousePosition = _playerInputs.player.camera.ReadValue<Vector2>();
        _yRotation += mousePosition.x * _sensitivityX;
        _xRotation += -mousePosition.y * _sensitivityY;

        transform.rotation = Quaternion.Euler(_xRotation, _yRotation, 0);
        direction.transform.rotation = Quaternion.Euler(0, _yRotation, 0);
    }
}
