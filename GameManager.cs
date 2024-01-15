using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button restartButton;
    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI gameOverText;
    public bool isGameActive;
    public int playerHealth = 3;

    void Start()
    {
        isGameActive = true;
        //start with Health: 3
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
        if (playerHealth <= 0) {
            healthText.text = "Game Over"; 
            GameOver();     
        }
    }

    public void AddHealth(int heal) {
        playerHealth += heal;
        healthText.text = "Health: " + playerHealth;      
    }



    public void GameOver() {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }

   public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}