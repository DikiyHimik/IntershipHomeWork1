using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private int _score;

    public event UnityAction<int> CoinCollected;
    public event UnityAction Died;

    private void Start()
    {
        _score = 0;
        CoinCollected?.Invoke(_score);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            collision.gameObject.SetActive(false);
            _score++;
            CoinCollected?.Invoke(_score);
        }
        else if (collision.TryGetComponent<Tree>(out Tree tree))
        {
            Die();
        }
    }

    private void Die()
    {
        Died?.Invoke();
    }
}
