using inputs;
using UnityEngine;
using UnityEngine.InputSystem;

//TODO player doesn't slide on side of walls 

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Transform dierection;
        private Rigidbody _rb;
        private CapsuleCollider _player;
        private Control _playerInputs;

        private float _movementSpeed = 2f;
    
        private float _jumpForce = 3f;

        private float _dragOnWalk = 3f;
        private float _dragOnCrouch = 6f;

        private float _playerHeight;
        private float _scaleOnCrouch = 0.75f;
        private float _getToCrouchSpeed = 25f;
    
        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _player = GetComponent<CapsuleCollider>();

            _playerInputs = new Control();
            _playerInputs.player.jump.performed += Jump;
        }
        private void Start()
        {
            _rb.drag = _dragOnWalk;
            _playerHeight = _player.height;
        
        }
        private void FixedUpdate()
        {
            Move();
            Crouch();
        }

        private void OnEnable()
        {
            _playerInputs.Enable();
        }
        private void OnDisable()
        {
            _playerInputs.Disable();
        }
    
        private bool IsOnGround()
        {
            float distanceToGround = _player.height / 2;
            return Physics.Raycast(transform.position, Vector3.down, distanceToGround + 0.1f);
        }

        private bool HittingCeiling()
        {
            float distanceToCeiling = _player.height / 2;
            return Physics.Raycast(transform.position, Vector3.up, distanceToCeiling + 0.2f);
        }
        private void Move()
        {
            Vector2 inputVector = _playerInputs.player.move.ReadValue<Vector2>();
            Vector3 direction = dierection.forward * inputVector.y + dierection.right * inputVector.x;
            _rb.AddForce(new Vector3(direction.x, 0, direction.z).normalized * (_movementSpeed * Time.deltaTime * 700));
        }
        private void Jump(InputAction.CallbackContext context)
        {
            if (IsOnGround())
                _rb.AddForce(new Vector3(0, 1, 0) * _jumpForce * 100);
        }
        private void Crouch()
        {
            bool isCrouching = _playerInputs.player.crouch.ReadValue<float>() > 0.1f;
            
            if (IsOnGround())
                _rb.drag = _dragOnCrouch;
            
            if (isCrouching)
                _player.height = Mathf.Lerp(_player.height, _playerHeight * _scaleOnCrouch, Time.deltaTime * _getToCrouchSpeed);
            else
                if (!HittingCeiling())
                    _player.height = Mathf.Lerp(_player.height, _playerHeight, Time.deltaTime * _getToCrouchSpeed);
        }
    }
}
