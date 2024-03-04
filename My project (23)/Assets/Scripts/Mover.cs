using UnityEngine;

public class Mover : MonoBehaviour
{   
    [SerializeField, Min(0)] private float _speed;
    [SerializeField] private Transform _target;
     
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);            
    }    
}
