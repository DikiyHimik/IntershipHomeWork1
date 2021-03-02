using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDeactivator : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Item>(out Item item))
        {
            collision.gameObject.SetActive(false);
        }
    }
}
