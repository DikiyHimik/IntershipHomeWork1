using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] private ObjectPool _objectPool;

    [SerializeField] protected float _secondsBetweenSpawn;

    private float _elapsedTime = 0;

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime > _secondsBetweenSpawn)
        {
            _elapsedTime = 0;

            GameObject creatingObject = _objectPool.GetObjectForCreating();

             SetObject(creatingObject);

            _objectPool.DisableObjectsAbroadScreen();
        }
    }

    public void SetObject(GameObject prefab)
    {
        prefab.transform.position = transform.position;
        prefab.SetActive(true);
    }
}
