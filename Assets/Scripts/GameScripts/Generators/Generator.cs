using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : ObjectPool
{
    [SerializeField] private GameObject _template;

    private float _secondsBetweenSpawn;

    private float _elapsedTime = 0;

    private void Start()
    {
        _secondsBetweenSpawn = Random.Range(1, 3);
        Initialize(_template);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime > _secondsBetweenSpawn)
        {
            if (TryGetObject(out GameObject item))
            {
                _elapsedTime = 0;
                _secondsBetweenSpawn = Random.Range(4, 7);
                item.transform.position = transform.position;
                item.SetActive(true);

                DisableObjectsAbroadScreen();
            }
        }
    }
}
