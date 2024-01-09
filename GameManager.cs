using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI gameOverText;
    public bool isGameActive;

    private int playerHealth = 4;

    void Start()
    {
        isGameActive = true;

        //start with Health: 4
        healthText.text = "Health: " + playerHealth; 
        UpdateScore(0);
    }
  
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;      
    }

    public void UpdateHealth(int damage) {
        playerHealth -= damage;
        healthText.text = "Health: " + playerHealth;      
        if (playerHealth == 0) {
            healthText.text = "Game Over"; 
            GameOver();     
        }
    }

    public void GameOver() {
        // restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }
}