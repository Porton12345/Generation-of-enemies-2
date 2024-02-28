using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Vector3 _direction;    
    [SerializeField] private Transform[] _spawnPoints;    
    [SerializeField] private Mover _mover;
    [SerializeField] private Transform _target;
    [SerializeField, Min(0)] private float _countSecondsBeforeSpawp;    
       
    private int minRandom = 0;
    private int maxRandom = 5;      

    private void Start()
    {        
        var wait = new WaitForSeconds(_countSecondsBeforeSpawp);
        StartCoroutine(Spawning(wait));
    }

    private void Spawn()
    {
        Vector3 _position;        
        int _currentSpawnpoint = Random.Range(minRandom, maxRandom);

        _position = _spawnPoints[_currentSpawnpoint].position;        
        Vector3 direction = (_target.position-transform.position).normalized;

        var enemy = Instantiate(_mover, _position, Quaternion.identity);           
        enemy.SetDirection(direction);       
    }

    private IEnumerator Spawning(WaitForSeconds wait)
    {
        while (true)
        {
            Spawn();
            yield return wait;
        }
    }
}