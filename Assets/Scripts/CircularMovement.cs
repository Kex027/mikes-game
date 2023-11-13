using UnityEngine;

//TODO is trigger enter 
//TODO add force (-direction)
public class CircularMovement : MonoBehaviour
{
    
    private float _angularSpeed = 8f;
    private float _circleRad = 2f;
 
    private Vector3 _startingPlace;
    private float _currentAngle;
 
    void Start()
    {
        _startingPlace = transform.position;
    }
 
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _currentAngle += _angularSpeed * Time.deltaTime;
        Vector2 offset = new Vector2(Mathf.Sin(_currentAngle), Mathf.Cos(_currentAngle)) * _circleRad;
        transform.position = new Vector3(offset.x + _startingPlace.x, _startingPlace.y, offset.y + _startingPlace.z);
    }
}
