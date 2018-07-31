using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {
    public bool isHorizontal;
    public bool shouldScoreForPlayer1;
    public bool shouldScoreForPlayer2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Miaou");
        if (isHorizontal)
            GameManager.Instance.FlipBallDirection(false);
        else
            GameManager.Instance.FlipBallDirection(true);

        if (shouldScoreForPlayer1)
            GameManager.Instance.ScorePlayer1();
        else if (shouldScoreForPlayer2)
            GameManager.Instance.ScorePlayer2();
    }
}
