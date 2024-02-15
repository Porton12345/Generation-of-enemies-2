using System.Collections;
using UnityEngine;

public class Mover : MonoBehaviour
{   
    [SerializeField, Min(0)] private float _speed;      

    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }   
}
