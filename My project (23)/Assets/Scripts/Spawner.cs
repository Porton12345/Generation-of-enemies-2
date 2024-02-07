using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private GameObject _enemyCapsule;

    public static Vector3 direction = new Vector3(0, 0, 0);

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
        direction = new Vector3(Random.Range(minRandom, maxRandom), 0, Random.Range(minRandom, maxRandom));
        Instantiate(_enemyCapsule, _position, Quaternion.identity);
    }

    private IEnumerator Countdown(float delay)
    {
        while (true)
        {
            CreateWithInstantiate();
            yield return new WaitForSeconds(2);
        }              
    }
}
