using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private float _score;
    [SerializeField] private Text _text;

    public event UnityAction PlayerDied;

    private void Start()
    {
        _score = 0;
        _text.text = _score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            collision.gameObject.SetActive(false);
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
        PlayerDied?.Invoke();
    }
}
