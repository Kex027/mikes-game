using inputs;
using Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class Shooting : MonoBehaviour
    {
        private Control _playerInputs;

        private void Awake()
        {
            _playerInputs = new Control();
            _playerInputs.player.shoot.performed += Shoot;
        }

        private void OnEnable()
        {
            _playerInputs.Enable();
        }

        private void OnDisable()
        {
            _playerInputs.Disable();
        }

        private void Shoot(InputAction.CallbackContext context)
        {
            if (Physics.Raycast(transform.position, transform.forward, out var hit)) // invert if
            {
                IShootable shootable = hit.transform.GetComponent<IShootable>(); //zobacz sobie try get component i go uzyj
                if (shootable != null)
                    shootable.Shoot(hit);
            }
        }
    }
}
