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
    [SerializeField] TMP_Text scoreText;
    [SerializeField] Image[] hearts;

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
        scoreText.text = score.ToString();
    }

    public void ProcessPlayerLives()
    {
        if (playerLives > 1)
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
        UpdateHearts();
    }


    public void AddLive()
    {
        if (playerLives >= 3) { return; }
        playerLives++;
        UpdateHearts();
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
    
    private void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < playerLives)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

}
