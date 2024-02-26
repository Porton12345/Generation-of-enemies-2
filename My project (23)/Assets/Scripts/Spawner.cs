using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Vector3 _direction;
    [SerializeField] private Mesh _mesh;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Enemy _enemy;
    [SerializeField, Min(0)] private float _countSecondsBeforeSpawp;
    [SerializeField] private Material _material;

    private Vector3 _position;
    private int minRandom = 0;
    private int maxRandom = 5;
    private int minRandomDegree = -100;
    private int maxRandomDegree = 100;
    private int _currentSpawnpoint = 0;

    private void Start()
    {
        var wait = new WaitForSeconds(_countSecondsBeforeSpawp);
        StartCoroutine(Countdown(wait));
    }

    private void CreateWithInstantiate()
    {           
        _currentSpawnpoint = Random.Range(minRandom, maxRandom);
        _position = _spawnPoints[_currentSpawnpoint].position;        
        Vector3 direction = new Vector3(Random.Range(minRandomDegree, maxRandomDegree), 0, Random.Range(minRandomDegree, maxRandomDegree));
        var enemy = Instantiate(_enemy, _position, Quaternion.identity); //Quaternion.LookRotation(direction));
        enemy.GetComponent<Renderer>().material = _material;
        enemy.transform.rotation = GetComponent<Mover>().SetDirection(direction);
    }

    private IEnumerator Countdown(WaitForSeconds wait)
    {
        while (true)
        {
            CreateWithInstantiate();
            yield return wait;
        }
    }
}