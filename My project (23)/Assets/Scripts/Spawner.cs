using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Vector3 _direction;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private GameObject _enemyCapsule;
    [SerializeField, Min(0)] private float _countSecondsBeforeSpawp;
    [SerializeField] private Material _material;

    private Vector3 _position;
    private int minRandom = 0;
    private int maxRandom = 5;
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
        Vector3 direction = new Vector3(Random.Range(minRandom, maxRandom), 0, Random.Range(minRandom, maxRandom));
        var enemy = Instantiate(_enemyCapsule, _position, Quaternion.LookRotation(_direction));
        enemy.GetComponent<Renderer>().material = _material;
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