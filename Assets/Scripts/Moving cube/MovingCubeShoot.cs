using Interfaces;
using UnityEngine;

namespace Moving_cube
{
    public class MovingCubeShoot : MonoBehaviour, IShootable
    {
        private MovingCube _circularMovement;

        private void Awake()
        {
            _circularMovement = GetComponent<MovingCube>();
        }

        public void Shoot(RaycastHit hit)
        {
            _circularMovement.moving = !_circularMovement.moving;
        }
    }
}
