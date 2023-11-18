using UnityEngine;

namespace Moving_cube
{
    public class CircularMovement : MonoBehaviour
    {
    
        private float _angularSpeed = 8f;
        private float _circleRad = 2f;
        private float _throwForce = 10f;
 
        private Vector3 _startingPlace;
        private float _currentAngle;

        public bool moving = true;

        private void Start()
        {
            _startingPlace = transform.position;
        }

        private void FixedUpdate()
        {
            if (moving)
                Move();
        }

        private void Move()
        {
            _currentAngle += _angularSpeed * Time.deltaTime;
            Vector2 offset = new Vector2(Mathf.Sin(_currentAngle), Mathf.Cos(_currentAngle)) * _circleRad;
            transform.position = new Vector3(offset.x + _startingPlace.x, _startingPlace.y, offset.y + _startingPlace.z);
        }

        private void OnTriggerEnter(Collider other)
        {
            Vector3 direction = -other.GetComponentInChildren<Transform>().forward + Vector3.up;
            other.GetComponent<Rigidbody>().AddForce(direction * _throwForce * 100);
        }
    }
}
