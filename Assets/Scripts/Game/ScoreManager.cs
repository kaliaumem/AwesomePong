using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI player1ScoreText;
    [SerializeField] private TMPro.TextMeshProUGUI player2ScoreText;

    private int player1Score = 0;
    private int player2Score = 0;

    private int maxScore = 10;

    // Set up scores for a clean new game
    public void NewGame()
    {
        player1Score = 0;
        player2Score = 0;
        UpdateScoreTexts();
    }

    // Set the score to reach
    // First player to reach this score wins
    public void ScoreToReach(int score)
    {
        maxScore = score;
    }

    // Increase the score, update the score texts and check if there's a winner
    public void IncreaseScore(PaddleSide player)
    {
        if (player == PaddleSide.LEFT)
            ++player1Score;
        else
            ++player2Score;
        UpdateScoreTexts();
        CheckVictoryConditions();
    }

    // Check the scores to pick a winner or play a new round
    private void CheckVictoryConditions()
    {
        if (player1Score >= maxScore)
            GameManager.Instance.GameOver(PaddleSide.LEFT);
        else if (player2Score >= maxScore)
            GameManager.Instance.GameOver(PaddleSide.RIGHT);
        else
            GameManager.Instance.NewRound();
    }

    // Update the score texts
    private void UpdateScoreTexts()
    {
        player1ScoreText.SetText(player1Score.ToString());
        player2ScoreText.SetText(player2Score.ToString());
    }
}
