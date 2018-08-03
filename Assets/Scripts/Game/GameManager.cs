using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public TMPro.TextMeshProUGUI winnerText;
    [SerializeField] private float timeBeforeBallMoves = 1.0f;
    [SerializeField] private UnityEvent newGameEvent;

    private BallController ball;
    private ScoreManager scoreManager;

    private void Awake()
    {
        Instance = this;
        ball = GameObject.FindObjectOfType<BallController>();
        scoreManager = GetComponent<ScoreManager>();
    }

    // Start a game
    public void Play()
    {
        if (ball == null)
            return;
        // Reset scores and score texts
        scoreManager.NewGame();
        // Reset the ball
        NewRound();
    }

    // End a game
    // Name the winner to see on the game settings menu
    public void GameOver(PaddleSide winner)
    {
        if (ball == null)
            return;
        ball.PutBackAtCenter();
        if (winner == PaddleSide.LEFT)
            winnerText.SetText("Last game winner: <color=#2932ff>Player 1</color>");
        else
            winnerText.SetText("Last game winner: <color=#ff2f35>Player 2</color>");
        winnerText.gameObject.SetActive(true);
        newGameEvent.Invoke(); // Unity events so some logic can be modified directly in the editor
    }

    // New round
    // Place the ball in the center and wait 1 second (or whatever timeBeforeBallMoves is) before launching it
    public void NewRound()
    {
        if (ball == null)
            return;
        ball.PutBackAtCenter();
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

    public void IncreaseScorePlayer(PaddleSide player)
    {
        // Score is handled in the ScoreManager object so pass the information to it
        scoreManager.IncreaseScore(player);
    }

    private void LaunchBall()
    {
        ball.moving = true;
    }
}
