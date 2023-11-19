using Interfaces;
using UnityEngine;

namespace Camera
{
    public class CameraShoot : MonoBehaviour, IShootable
    {
        [SerializeField] private int cameraNumber;

        public void Shoot(RaycastHit hit)
        {
            CameraSwitch.Instance.ChangeToNewCamera(cameraNumber);
        }
    }
}