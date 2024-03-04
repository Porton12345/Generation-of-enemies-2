using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{          
    [SerializeField] private SpawnerPoints[] _spawningPoint;    
    [SerializeField, Min(0)] private float _countSecondsBeforeSpawp;    
       
    private int minRandom = 0;
    private int maxRandom = 3;      

    private void Start()
    {        
        var wait = new WaitForSeconds(_countSecondsBeforeSpawp);
        StartCoroutine(Spawning(wait));
    }

    private IEnumerator Spawning(WaitForSeconds wait)
    {
        while (true)
        {
            ActivatePoint();
            yield return wait;
        }
    }

    private void ActivatePoint()
    {       
        int _currentSpawnPoint = Random.Range(minRandom, maxRandom);
        SpawnerPoints SpawnerPoint = _spawningPoint[_currentSpawnPoint];
        SpawnerPoint.Spawn();
    }    
}