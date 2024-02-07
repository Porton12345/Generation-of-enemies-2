using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private GameObject _enemyCapsule;       

    private Vector3 _position;
    private int minRandom = 0;
    private int maxRandom = 5;    
    private int _currentSpawnpoint = 0;
         

    private void Start()
    {
        StartCoroutine(Countdown(2));        
    }    
    
    private void CreateWithInstantiate()
    {
        _currentSpawnpoint = Random.Range(minRandom, maxRandom);
        _position = _spawnPoints[_currentSpawnpoint].position;
        Vector3 direction = new Vector3(Random.Range(minRandom, maxRandom), 0, Random.Range(minRandom, maxRandom));
        var enemy = Instantiate(_enemyCapsule, _position, Quaternion.identity);
        enemy.SetDirection(direction);
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
