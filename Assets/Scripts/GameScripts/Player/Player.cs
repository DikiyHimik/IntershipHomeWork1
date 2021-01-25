using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Text _text;

    private int _score;

    public event UnityAction<int> CoinCollecting;
    public event UnityAction GameOver;

    private void Start()
    {
        _score = 0;
        CoinCollecting?.Invoke(_score);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            collision.gameObject.SetActive(false);
            _score++;
            CoinCollecting?.Invoke(_score);
        }
        else
        {
            Die();
        }
    }

    public void Die()
    {
        GameOver?.Invoke();
    }
}
