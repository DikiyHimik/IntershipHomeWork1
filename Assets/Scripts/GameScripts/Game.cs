using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;

    public void OnEnable()
    {
        _player.GameOver += OnGameOver;
    }

    public void OnDisable()
    {
        _player.GameOver -= OnGameOver;
    }

    public void OnGameOver()
    {
        SceneManager.LoadScene(0);
    }
}
