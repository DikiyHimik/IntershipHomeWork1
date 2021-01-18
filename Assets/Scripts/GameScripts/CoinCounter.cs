using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private Player _player;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
        OnScoreChanging(0);
    }

    public void OnEnable()
    {
        _player.ScoreChanging += OnScoreChanging;
    }

    public void OnDisable()
    {
        _player.ScoreChanging -= OnScoreChanging;
    }

    public void OnScoreChanging(int score)
    {
        _scoreText.text = score.ToString();
    }
}
