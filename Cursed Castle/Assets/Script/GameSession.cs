using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    private void Awake()
    {
        int numerOfGameSesions = FindObjectsOfType<GameSession>().Length;

        if (numerOfGameSesions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }

    public void ProcessPlayerLives()
    {
        if (playerLives >= 1)
        {
            TakeDamage();

        }
        else
        {
            LoadGameOver();
        }
        return;

    }

    private void TakeDamage()
    {
        playerLives--;
    }

    private void LoadGameOver()
    {
        SceneManager.LoadScene(4);
    }
}
