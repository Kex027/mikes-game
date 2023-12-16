using inputs;
using UnityEngine;

namespace Camera
{
    public class CameraMovement : MonoBehaviour
    {
        private CapsuleCollider _player;
        [SerializeField] private Transform direction;
        private Control _playerInputs;
    
        [SerializeField] private GameObject[] cameraSpots; // bym zrobil camera spot manager na singletonie z ta lista 
        private float _xRotation = 0;                      // i stamtad bierzes te spoty najlpeiej
        private float _yRotation = 0;
        private float _sensitivityX = 0.25f;
        private float _sensitivityY = 0.25f;
        private Vector3 _firstPersonCameraPosition; // powinienes do gracza dodac tez camera spot i tyle eliminuje to problemy

        private void Awake()
        {
            _player = GetComponentInParent<CapsuleCollider>();
            _playerInputs = new Control();
        }

        private void Start()
        {
            CameraSwitch.Instance.OnChangedCamera.AddListener(HandleCameraPosition);

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            
            _firstPersonCameraPosition = new Vector3(transform.localPosition.x, _player.height / 2 * 0.5f, transform.localPosition.z);
            transform.localPosition = _firstPersonCameraPosition;
        }

        private void Update()
        {
            RotateCameraAndPlayer();
        }

        void OnEnable()
        {
            _playerInputs.Enable();
        }
        void OnDisable()
        {
            _playerInputs.Disable();
        }

        void HandleCameraPosition()
        {
            transform.localPosition = Vector3.zero; 
            transform.localEulerAngles = Vector3.zero;

            switch (CameraSwitch.Instance.GetCurrentCamera()) //japierdole ☠️☠️☠️☠️☠️☠️☠️☠️☠️☠️☠️☠️
            {
                case 1:
                    transform.SetParent(cameraSpots[0].transform, false); // tak jak pisalem wyzej eliminutje to problem ten
                    transform.localPosition = new Vector3(transform.localPosition.x, _player.height / 2 * 0.5f, transform.localPosition.z);
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
                    transform.localPosition = new Vector3(transform.localPosition.x, _player.height / 2 * 0.5f, transform.localPosition.z);
                    break;
            }
        }

        private void RotateCameraAndPlayer()
        {
            Vector2 mousePosition = _playerInputs.player.camera.ReadValue<Vector2>(); // tak samo jak w player movement pisalem cachijsz to wyzej
            _yRotation += mousePosition.x * _sensitivityX;
            _xRotation += -mousePosition.y * _sensitivityY;
            _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

            transform.rotation = Quaternion.Euler(_xRotation, _yRotation, 0);
            direction.transform.rotation = Quaternion.Euler(0, _yRotation, 0);
        }
    }
}
