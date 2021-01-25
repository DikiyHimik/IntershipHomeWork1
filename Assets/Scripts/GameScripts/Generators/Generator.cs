using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] private GameObject _template;
    [SerializeField] private ObjectPool _objectPool;

    [SerializeField] protected float _secondsBetweenSpawn;

    private float _elapsedTime = 0;

    private void Start()
    {
        _objectPool.Initialize(_template);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime > _secondsBetweenSpawn)
        {
            _elapsedTime = 0;

            if (!_objectPool.TryGetObject(out GameObject item))
            {
                item = Instantiate(_template);
                _objectPool.AddObjectInPool(item);
            }

             _objectPool.SetObject(item, transform.position);

            _objectPool.DisableObjectsAbroadScreen();
        }
    }
}
