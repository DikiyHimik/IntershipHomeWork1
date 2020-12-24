using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Text _text;
    private int _score;

    public event UnityAction GameOver;

    private void Start()
    {
        _score = 0;
        _text.text = _score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            Destroy(coin.gameObject);
            _score++;
            _text.text = _score.ToString();
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
