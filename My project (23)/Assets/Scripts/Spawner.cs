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
                SpawnInFirstPoint(_position, FirstSpawnPoint);
                break;
            case SecondSpawnPoint:
                SecondSpawner(_position, SecondSpawnPoint);
                break;
            case ThirdSpawnPoint:
                ThirdSpawner(_position, ThirdSpawnPoint);
                break;
            case FourthSpawnPoint:
                FourSpawner(_position, FourthSpawnPoint);
                break;
            case FifthSpawnPoint:
                FiveSpawner(_position, FifthSpawnPoint);
                break;             
        }       
    }

    private void SpawnInFirstPoint(Vector3 _position, int FirstSpawnPoint)
    {        
        _position = _spawnPoints[FirstSpawnPoint].position;
        var enemy = Instantiate(_mover[FirstSpawnPoint], _position, Quaternion.identity);
        Vector3 direction = (_target[FirstSpawnPoint].position - transform.position).normalized;
        enemy.SetDirection(direction);
    }

    private void SecondSpawner(Vector3 _position, int SecondSpawnPoint)
    {
        _position = _spawnPoints[SecondSpawnPoint].position;
        var enemy = Instantiate(_mover[SecondSpawnPoint], _position, Quaternion.identity);
        Vector3 direction = (_target[SecondSpawnPoint].position - transform.position).normalized;
        enemy.SetDirection(direction);
    }

    private void ThirdSpawner(Vector3 _position, int ThirdSpawnPoint)
    {
        _position = _spawnPoints[ThirdSpawnPoint].position;
        var enemy = Instantiate(_mover[ThirdSpawnPoint], _position, Quaternion.identity);
        Vector3 direction = (_target[ThirdSpawnPoint].position - transform.position).normalized;
        enemy.SetDirection(direction);
    }

    private void FourSpawner(Vector3 _position, int FourthSpawnPoint)
    {
        _position = _spawnPoints[FourthSpawnPoint].position;
        var enemy = Instantiate(_mover[FourthSpawnPoint], _position, Quaternion.identity);
        Vector3 direction = (_target[FourthSpawnPoint].position - transform.position).normalized;
        enemy.SetDirection(direction);
    }

    private void FiveSpawner(Vector3 _position, int FifthSpawnPoint)
    {        
        _position = _spawnPoints[FifthSpawnPoint].position;
        var enemy = Instantiate(_mover[FifthSpawnPoint], _position, Quaternion.identity);
        Vector3 direction = (_target[FifthSpawnPoint].position - transform.position).normalized;
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