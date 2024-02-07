using System.Collections;
using UnityEngine;

public class Mover : MonoBehaviour
{   
    public float _speed = 0.01f;      

    public void SetDirection(Vector3 direction)
    {
        transform.Translate(direction * _speed);
    }   
}
