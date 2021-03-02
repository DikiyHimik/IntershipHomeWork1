using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    [SerializeField] private ObjectPool _objectPool;
    [SerializeField] private float _secondsBetweenSpawn;

    private float _elapsedTime = 0;

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime > _secondsBetweenSpawn)
        {
            _elapsedTime = 0;

            GameObject item = _objectPool.GetObject();

            item.transform.position = transform.position;
            item.SetActive(true);
        }
    }
}
