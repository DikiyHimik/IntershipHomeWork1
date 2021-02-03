using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private GameObject _template;
    [SerializeField] private float _capacity;

    private Camera _camera;

    private List<GameObject> _pool = new List<GameObject>();

    private void Awake()
    {
        Initialize(_template);
    }

    private void Initialize(GameObject prefab)
    {
        _camera = Camera.main;

        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(prefab, _container.transform);
            spawned.SetActive(false);

            _pool.Add(spawned);
        }
    }

    public GameObject GetObject()
    {
        GameObject item = TryGetObject();

        if (item == null)
        {
            item = Instantiate(_template);
            _pool.Add(item);
        }

        return item;
    }

    private GameObject TryGetObject()
    {
        GameObject result = _pool.FirstOrDefault(p => p.activeSelf == false);
        return result;
    }

    public void ResetPool()
    {
        foreach (var item in _pool)
        {
            item.SetActive(false);
        }
    }
}
