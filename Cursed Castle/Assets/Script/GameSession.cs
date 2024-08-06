using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3, score = 0;
    [SerializeField] TMP_Text livesText, scoreText;

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

    private void Start()
    {
        livesText.text = playerLives.ToString();
        scoreText.text = score.ToString();
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
        livesText.text = playerLives.ToString();
    }

    public void AddLive()
    {
        playerLives++;
        livesText.text = playerLives.ToString();
    }

    public void AddScore(int value)
    {
        score += value;
        scoreText.text = score.ToString();
    }

    private void LoadGameOver()
    {
        SceneManager.LoadScene(4);
    }
}
