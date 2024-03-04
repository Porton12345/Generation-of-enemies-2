using UnityEngine;

public class SpawnerPoints : MonoBehaviour
{       
    [SerializeField] private Mover _mover;        
    [SerializeField] private Vector3 _position;         

    public void Spawn()
    {  
        var enemy = Instantiate(_mover, _position, Quaternion.identity);            
    }
}