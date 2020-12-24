using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _secondBetweenSpawn;

    private float _elapsedTime = 0;

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _secondBetweenSpawn)
        {
            _elapsedTime = 0;
            Instantiate(_prefab, _spawnPoint.position, Quaternion.identity);
        }
    }
}
