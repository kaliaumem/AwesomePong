using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class GameOverTest : UITest
{
    [UnityTest]
    public IEnumerator WinPlayer1()
    {
        yield return LoadScene("GameScene");

        yield return WaitFor(new ObjectAppeared<GameManager>());
        yield return WaitFor(new ObjectAppeared<ScoreManager>());

        GameManager.Instance.GetComponent<ScoreManager>().ScoreToReach(1);
        GameManager.Instance.Play();

        BallController ball = Object.FindObjectOfType<BallController>();
        ball.ballSpeed = new Vector2(0.75f, 0.25f);

        yield return WaitFor(new BoolCondition(() => ball.moving == true));
        yield return WaitFor(new BoolCondition(() => ball.moving == false));

        Assert.IsTrue(GameManager.Instance.winnerText.text.Contains("Player 1"));
    }

    [UnityTest]
    public IEnumerator WinPlayer2()
    {
        yield return LoadScene("GameScene");

        yield return WaitFor(new ObjectAppeared<GameManager>());
        yield return WaitFor(new ObjectAppeared<ScoreManager>());

        GameManager.Instance.GetComponent<ScoreManager>().ScoreToReach(1);
        GameManager.Instance.Play();

        BallController ball = Object.FindObjectOfType<BallController>();
        ball.ballSpeed = new Vector2(-0.75f, 0.25f);

        yield return WaitFor(new BoolCondition(() => ball.moving == true));
        yield return WaitFor(new BoolCondition(() => ball.moving == false));

        Assert.IsTrue(GameManager.Instance.winnerText.text.Contains("Player 2"));
    }
}
