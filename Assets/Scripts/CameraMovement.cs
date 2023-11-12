using UnityEngine;
using inputs;

public class CameraMovement : MonoBehaviour
{
    private CapsuleCollider _player;
    private Control _playerInputs;
    
    private Camera _camera;
    [SerializeField] private GameObject[] cameraSpots;
    private float _rotationSpeed = 2f;
    private Vector3 _firstPersonCameraPosition;

    private void Awake()
    {
        _player = GetComponentInParent<CapsuleCollider>();
        _camera = GetComponent<Camera>();
        _playerInputs = new Control();
        _firstPersonCameraPosition = new Vector3(_player.transform.position.x, _player.height * 0.75f, _player.transform.position.z);
    }

    private void Start()
    {
        _camera.transform.position = _firstPersonCameraPosition;
    }
    private void FixedUpdate()
    {
        HandleCameraPosition();
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
    {
        switch (CameraSwitch.Instance.GetCurrentCamera())
        {
            case 1:
                _camera.transform.SetParent(cameraSpots[0].transform, false);
                Vector3 position = _player.transform.position;
                _firstPersonCameraPosition = new Vector3(position.x, position.y - 1 + _player.height * 0.75f, position.z);
                _camera.transform.position = _firstPersonCameraPosition;
                break;
            case 2:
                _camera.transform.SetParent(cameraSpots[1].transform, false);
                break;
            case 3:
                _camera.transform.SetParent(cameraSpots[2].transform, false);
                break;
            case 4:
                _camera.transform.SetParent(cameraSpots[3].transform, false);
                break;
            default:
                _camera.transform.SetParent(cameraSpots[0].transform, false);
                break;
        }
    }

    private void RotateCameraAndPlayer()
    {
        Vector2 mousePosition = _playerInputs.player.camera.ReadValue<Vector2>();
        
        if (CameraSwitch.Instance.GetCurrentCamera() == 1)
            _camera.transform.eulerAngles = new Vector3(-mousePosition.y, mousePosition.x, 0) * (_rotationSpeed * Time.deltaTime);

        _player.transform.eulerAngles = new Vector3(0, mousePosition.x, 0) * (_rotationSpeed * Time.deltaTime);
    }
}
