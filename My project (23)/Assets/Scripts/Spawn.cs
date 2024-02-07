using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private GameObject _enemyCapsule;

    public static Vector3 direction = new Vector3(0, 0, 0);

    private Vector3 _position;
    private int minRandom = 0;
    private int maxRandom = 5;
    private float _runningTime = 0;
    private float _durationTime = 2.0f;
    private int _currentWaypoint = 0;
    

    private void Update()
    {        
        _runningTime += Time.deltaTime;

        if ( _runningTime >= _durationTime)
        {            
            CreateWithInstantiate();
            _runningTime = 0;
        }       
    }    
    
    private void CreateWithInstantiate()
    {
        _currentWaypoint = Random.Range(minRandom, maxRandom);
        _position = _waypoints[_currentWaypoint].position;
        direction = new Vector3(Random.Range(minRandom, maxRandom), 0, Random.Range(minRandom, maxRandom));
        Instantiate(_enemyCapsule, _position, Quaternion.identity);
    }
}
