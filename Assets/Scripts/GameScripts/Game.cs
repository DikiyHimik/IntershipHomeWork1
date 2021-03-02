using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;

    public void OnEnable()
    {
        _player.Died += GameOver;
    }

    public void OnDisable()
    {
        _player.Died -= GameOver;
    }

    private void GameOver()
    {
        SceneManager.LoadScene(0);
    }
}
