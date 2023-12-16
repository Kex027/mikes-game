using inputs;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class Generating : MonoBehaviour
    {
        private Control _playerInputs;

        private void Awake()
        {
            _playerInputs = new Control();
            _playerInputs.player.generate.performed += Generate; //tu wsm nie widzi sie tego czesto ale moze byc i guess
        }

        private void OnEnable()
        {
            _playerInputs.Enable();
        }
        private void OnDisable()
        {
            _playerInputs.Disable();
        }
        
        private void Generate(InputAction.CallbackContext obj)
        {
            if (Physics.Raycast(transform.position, transform.forward, out var hit))
            {
                GameObject barrel = ObjectPool.SharedInstance.GetPooledObject();
                if (barrel != null)
                {
                    barrel.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    barrel.transform.rotation = Quaternion.identity;
                    barrel.transform.position = hit.point + new Vector3(0, 0.1f + barrel.transform.lossyScale.y / 2, 0);
                    barrel.SetActive(true);
                }
            }
        }
    }
}