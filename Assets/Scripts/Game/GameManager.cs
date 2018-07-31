using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Text Player1ScoreLabel;
    public Text Player2ScoreLabel;

    private int Player1Score;
    private int Player2Score;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        Player1ScoreLabel.text = Player1Score.ToString();
        Player2ScoreLabel.text = Player2Score.ToString();
    }

    public void FlipBallDirection(bool isXAxis)
    {
        GameObject ball = GameObject.Find("ball");
        if (ball != null)
        {
            BallController ballController = ball.GetComponent<BallController>();
            if (ballController != null)
            {
                if (isXAxis)
                {
                    ballController.ballSpeed.x = -ballController.ballSpeed.x;
                }
                else
                {
                    ballController.ballSpeed.y = -ballController.ballSpeed.y;
                }
            }
        }
    }

    public void ScorePlayer1()
    {
        Player1Score++;
        GameObject ball = GameObject.Find("ball");
        if (ball != null)
        {
            BallController ballController = ball.GetComponent<BallController>();
            if (ballController != null)
            {
                ballController.PutBackAtCenter();
            }
        }
    }

    public void ScorePlayer2()
    {
        Player2Score++;
        GameObject ball = GameObject.Find("ball");
        if (ball != null)
        {
            BallController ballController = ball.GetComponent<BallController>();
            if (ballController != null)
            {
                ballController.PutBackAtCenter();
            }
        }
    }
}
