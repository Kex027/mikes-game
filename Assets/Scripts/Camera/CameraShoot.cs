using UnityEngine;

namespace Camera
{
    public class CameraShoot : MonoBehaviour, IShootable
    {
        [SerializeField] private int cameraNumber;
        public void Shoot()
        {
            CameraSwitch.Instance.ChangeToNewCamera(cameraNumber);
        }
    }
}