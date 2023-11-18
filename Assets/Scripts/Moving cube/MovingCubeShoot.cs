using UnityEngine;

namespace Moving_cube
{
    public class MovingCubeShoot : MonoBehaviour, IShootable
    {
        private CircularMovement _circularMovement;

        private void Awake()
        {
            _circularMovement = GetComponent<CircularMovement>();
        }
    
        public void Shoot()
        {
            _circularMovement.moving = !_circularMovement.moving;
        }
    }
}
