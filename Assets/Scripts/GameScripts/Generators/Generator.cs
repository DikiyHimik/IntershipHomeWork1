using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : ObjectPool
{
    [SerializeField] protected float _secondsBetweenSpawn;

    [SerializeField] private GameObject _template;

    private float _elapsedTime = 0;

    private void Start()
    {
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
                item.transform.position = transform.position;
                item.SetActive(true);

                DisableObjectsAbroadScreen();
            }
        }
    }
}
