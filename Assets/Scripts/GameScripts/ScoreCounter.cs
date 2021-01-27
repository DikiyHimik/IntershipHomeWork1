using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private Player _player;

    private void Start()
    {
        OnScoreChanging(0);
    }

    public void OnEnable()
    {
        _player.CoinCollecting += OnScoreChanging;
    }

    public void OnDisable()
    {
        _player.CoinCollecting -= OnScoreChanging;
    }

    public void OnScoreChanging(int score)
    {
        _scoreText.text = score.ToString();
    }
}
