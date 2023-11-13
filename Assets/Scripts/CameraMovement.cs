using System;
using UnityEngine;
using inputs;


//TODO nie moge zrobic pelnego obrotu myszkiem
public class CameraMovement : MonoBehaviour
{
    private CapsuleCollider _player;
    [SerializeField] private Transform direction;
    private Control _playerInputs;
    
    [SerializeField] private GameObject[] cameraSpots; // chcesz pozycje tych punktow wiec bardzij oplaca sie brac transform a nie gameobject ( o jeden get mniej )
    private float _xRotation = 0;
    private float _yRotation = 0;
    [SerializeField] private float _sensinitivityX = 1000f;
    [SerializeField] private float _sensinitivityY = 1000f;
    private Vector3 _firstPersonCameraPosition;

    private void Awake()
    {
        _player = GetComponentInParent<CapsuleCollider>();
        _playerInputs = new Control();
        _firstPersonCameraPosition = new Vector3(_player.transform.position.x, _player.height * 0.75f, _player.transform.position.z); // zobacz czym jest local position
    }

    private void Start()
    {
        transform.position = _firstPersonCameraPosition;
        Cursor.lockState = CursorLockMode.Locked; //:sunglesses: git
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
                Vector3 position = _player.transform.position;
                _firstPersonCameraPosition = new Vector3(position.x, position.y - 1 + _player.height * 0.75f, position.z); // zobacz czym jest local position
                transform.position = _firstPersonCameraPosition;
                break;
            case 2:
                transform.SetParent(cameraSpots[1].transform, false);
                break;
            case 3:
                transform.SetParent(cameraSpots[2].transform, false);
                break;
            case 4:
                transform.SetParent(cameraSpots[3].transform, false);
                break;
            default:
                transform.SetParent(cameraSpots[0].transform, false);
                break;
        }
    }

    private void RotateCameraAndPlayer()
    {
        Vector2 mousePosition = _playerInputs.player.camera.ReadValue<Vector2>();
        _yRotation += mousePosition.x * _sensinitivityX;
        _xRotation += -mousePosition.y * _sensinitivityY;

        if (CameraSwitch.Instance.GetCurrentCamera() == 1) // wyjebac to z updacji nie ma byc ifa zadnego
            transform.rotation = Quaternion.Euler(_xRotation, _yRotation, 0);

        // _player.transform.eulerAngles = new Vector3(0, mousePosition.x, 0) * (_sensinitivityX * Time.deltaTime);
        direction.transform.rotation = Quaternion.Euler(0, _yRotation, 0);
    }
}
