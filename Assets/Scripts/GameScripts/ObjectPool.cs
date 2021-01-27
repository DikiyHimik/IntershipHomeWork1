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

    public void Initialize(GameObject prefab)
    {
        _camera = Camera.main;

        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(prefab, _container.transform);
            spawned.SetActive(false);

            _pool.Add(spawned);
        }
    }

    public GameObject GetObjectForCreating()
    {
        GameObject creatingObject = TryGetObject();

        if (creatingObject == null)
        {
            creatingObject = Instantiate(_template);
            _pool.Add(gameObject);
        }

        return creatingObject;
    }

    public GameObject TryGetObject()
    {
        GameObject result = _pool.FirstOrDefault(p => p.activeSelf == false);
        return result;
    }

    public void DisableObjectsAbroadScreen()
    {
        Vector3 disablePoint = _camera.ViewportToWorldPoint(new Vector2(0, 0.5f));

        foreach (var item in _pool)
        {
            if (item.activeSelf == true)
            {
                if(item.transform.position.x < disablePoint.x)
                {
                    item.SetActive(false);
                }
            }
        }
    }

    public void ResetPool()
    {
        foreach (var item in _pool)
        {
            item.SetActive(false);
        }
    }
}
