using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro; 
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [Header("UI Images")]
    public Image playerImage;
    public Image computerImage;

    [Header("UI Text")]
    public TMP_Text winnerText;       
    public TMP_Text playerScoreText;  
    public TMP_Text computerScoreText; 

    [Header("Pop Up Settings")]
    public GameObject gameOverPanel;   
    public TMP_Text finalWinnerText;   

    [Header("Hand Sprites")]
    public Sprite rockSprite;
    public Sprite paperSprite;
    public Sprite scissorSprite;
     

    int playerScore = 0;
    int computerScore = 0;
    bool gameIsOver = false; 

    public void onClicked(GameObject ButtonObject)
    {
    
        if (gameIsOver == true) return; 

        string playerChoice = "";
        string computerChoice = "";

       
        if (ButtonObject.name.Contains("Rock"))
        {
            playerChoice = "Rock";
            playerImage.sprite = rockSprite;
        }
        else if (ButtonObject.name.Contains("Paper"))
        {
            playerChoice = "Paper";
            playerImage.sprite = paperSprite;
        }
        else if (ButtonObject.name.Contains("Scissor"))
        {
            playerChoice = "Scissor";
            playerImage.sprite = scissorSprite;
        }

        
        int randomNum = Random.Range(0, 3);
        if (randomNum == 0)
        {
            computerChoice = "Rock";
            computerImage.sprite = rockSprite;
        }
        else if (randomNum == 1)
        {
            computerChoice = "Paper";
            computerImage.sprite = paperSprite;
        }
        else
        {
            computerChoice = "Scissor";
            computerImage.sprite = scissorSprite;
        }

        checkWinner(playerChoice, computerChoice);
    }

    void checkWinner(string player, string computer)
    {
        if (player == computer)
        {
            winnerText.text = "It is a Draw!";
        }
        else if ((player == "Rock" && computer == "Scissor") ||
                 (player == "Paper" && computer == "Rock") ||
                 (player == "Scissor" && computer == "Paper"))
        {
            winnerText.text = "Player Wins!";
            playerScore++;
            playerScoreText.text = playerScore.ToString();
        }
        else
        {
            winnerText.text = "Computer Wins!";
            computerScore++;
            computerScoreText.text = computerScore.ToString();
        }

     
        if (playerScore >= 3)
        {
            ShowGameOver("YOU WON THE GAME!");
        }
        else if (computerScore >= 3)
        {
            ShowGameOver("COMPUTER WON THE GAME!");
        }
    }

    void ShowGameOver(string message)
    {
        gameIsOver = true;
        Invoke("showGameOverPanel", 1.5f);
      
        finalWinnerText.text = message;
    }


    void showGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }


  
}