using UnityEngine;

public class Mover : MonoBehaviour
{   
    [SerializeField, Min(0)] private float _speed;
    
    public void SetDirection(Vector3 direction)
    {
        transform.rotation = Quaternion.LookRotation(direction);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }      
}
