using UnityEngine;

public class Mover : MonoBehaviour
{   
    private float _speed = 0.01f;    
    private Vector3 _movementDirection;

    private void Start()
    {
        _movementDirection = Spawner.direction;        
    }

    private void Update()
    {   
        transform.Translate(_movementDirection * _speed);
    }
}
