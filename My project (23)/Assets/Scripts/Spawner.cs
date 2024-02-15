using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Vector3 _direction;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private GameObject _enemyCapsule;
    [SerializeField, Min(0)] private float _countSecondsBeforeSpawp;

    private Vector3 _position;
    private int minRandom = 0;
    private int maxRandom = 5;    
    private int _currentSpawnpoint = 0;
         

    private void Start()
    {
        StartCoroutine(Countdown(_countSecondsBeforeSpawp));        
    }    
    
    private void CreateWithInstantiate()
    {
        _currentSpawnpoint = Random.Range(minRandom, maxRandom);
        _position = _spawnPoints[_currentSpawnpoint].position;
        Vector3 direction = new Vector3(Random.Range(minRandom, maxRandom), 0, Random.Range(minRandom, maxRandom));
        var enemy = Instantiate(_enemyCapsule, _position, Quaternion.LookRotation(_direction));       
    }    

    private IEnumerator Countdown(float delay)
    {
        while (true)
        {
            CreateWithInstantiate();
            yield return new WaitForSeconds(delay);
        }              
    }    
}
