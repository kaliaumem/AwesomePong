using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public TMPro.TextMeshProUGUI Player1ScoreLabel;
    public TMPro.TextMeshProUGUI Player2ScoreLabel;
    public float timeBeforeBallMoves = 1.0f;

    private BallController ball;
    private int Player1Score;
    private int Player2Score;

    private void Awake()
    {
        Instance = this;
        ball = GameObject.FindObjectOfType<BallController>();
        Player1ScoreLabel.SetText(Player1Score.ToString());
        Player2ScoreLabel.SetText(Player2Score.ToString());
        Invoke("LaunchBall", timeBeforeBallMoves);
    }

    public void FlipBallDirection(bool isXAxis)
    {
        if (ball != null)
        {
            if (isXAxis)
                ball.ballSpeed.x = -ball.ballSpeed.x;
            else
                ball.ballSpeed.y = -ball.ballSpeed.y;
        }
    }

    public void IncreaseScorePlayer(bool player1)
    {
        if (player1)
        {
            Player1Score++;
            Player1ScoreLabel.SetText(Player1Score.ToString());
        }
        else
        {
            Player2Score++;
            Player2ScoreLabel.SetText(Player2Score.ToString());
        }
        if (ball != null)
        {
            ball.PutBackAtCenter();
            Invoke("LaunchBall", timeBeforeBallMoves);
        }
    }

    private void LaunchBall()
    {
        ball.moving = true;
    }
}
