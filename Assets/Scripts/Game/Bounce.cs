using UnityEngine;

public class Bounce : MonoBehaviour
{
    public bool isHorizontal;
    public bool shouldScoreForPlayer1;
    public bool shouldScoreForPlayer2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isHorizontal)
            GameManager.Instance.FlipBallDirection(false);
        else
            GameManager.Instance.FlipBallDirection(true);

        if (shouldScoreForPlayer1)
            GameManager.Instance.IncreaseScorePlayer(true);
        else if (shouldScoreForPlayer2)
            GameManager.Instance.IncreaseScorePlayer(false);
    }
}
