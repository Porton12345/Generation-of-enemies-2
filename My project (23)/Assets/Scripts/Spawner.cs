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
        const int FirstSpawnPoint = 0;
        const int SecondSpawnPoint = 1;
        const int ThirdSpawnPoint = 2;
        const int FourthSpawnPoint = 3;
        const int FifthSpawnPoint = 4;                 
               
        int _currentSpawnpoint = Random.Range(minRandom, maxRandom);

        Vector3 _position = _spawnPoints[_currentSpawnpoint].position;

        switch (_currentSpawnpoint)
        {
            case FirstSpawnPoint:
                SpawnInPoint(_position, FirstSpawnPoint);
                break;
            case SecondSpawnPoint:
                SpawnInPoint(_position, SecondSpawnPoint);
                break;
            case ThirdSpawnPoint:
                SpawnInPoint(_position, ThirdSpawnPoint);
                break;
            case FourthSpawnPoint:
                SpawnInPoint(_position, FourthSpawnPoint);
                break;
            case FifthSpawnPoint:
                SpawnInPoint(_position, FifthSpawnPoint);
                break;             
        }       
    }

    private void SpawnInPoint(Vector3 _position, int FirstSpawnPoint)
    {        
        _position = _spawnPoints[FirstSpawnPoint].position;
        var enemy = Instantiate(_mover[FirstSpawnPoint], _position, Quaternion.identity);
        Vector3 direction = (_target[FirstSpawnPoint].position - transform.position).normalized;
        enemy.SetDirection(direction);
    }    
}