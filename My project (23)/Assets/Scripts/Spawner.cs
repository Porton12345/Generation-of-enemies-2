using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Vector3 _direction;    
    [SerializeField] private Transform[] _spawnPoints;    
    [SerializeField] private Mover[] _mover;
    [SerializeField] private Transform[] _target;
    [SerializeField, Min(0)] private float _countSecondsBeforeSpawp;    
       
    private int minRandom = 0;
    private int maxRandom = 5;      

    private void Start()
    {        
        var wait = new WaitForSeconds(_countSecondsBeforeSpawp);
        StartCoroutine(Spawning(wait));
    }

    private IEnumerator Spawning(WaitForSeconds wait)
    {
        while (true)
        {
            Spawn();
            yield return wait;
        }
    }

    private void Spawn()
    {       
        int _currentSpawnpoint = Random.Range(minRandom, maxRandom);
        Vector3 _position = _spawnPoints[_currentSpawnpoint].position;
        
        var enemy = Instantiate(_mover[_currentSpawnpoint], _position, Quaternion.identity);
        Vector3 direction = (_target[_currentSpawnpoint].position - transform.position).normalized;
        enemy.SetDirection(direction);       
    }    
}