using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Vector3 _direction;    
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Mover _mover;
    [SerializeField] private Transform _target;
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
        Vector3 direction = (_target.position-transform.position).normalized;
        var enemy = Instantiate(_enemy, _position, Quaternion.identity); 
        enemy.GetComponent<Renderer>().material = _material;        
        var mover = Instantiate(_mover);
        enemy.AddComponent<Mover>();
        enemy.transform.rotation = mover.SetDirection(direction);       
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