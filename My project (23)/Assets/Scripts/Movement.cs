using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{   
    private float _speed = 0.01f;
    private static float minRandom = -1.0f;
    private static float maxRandom = 1.0f;
    private Vector3 _movementDirection;

    private void Start()
    {
        _movementDirection = Spawn.direction;        
    }

    private void Update()
    {   
        transform.Translate(_movementDirection * _speed);
    }
}
