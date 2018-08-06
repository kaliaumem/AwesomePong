using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class ScoreTest : UITest
{
    [UnityTest]
    public IEnumerator CheckScoreLabels()
    {
        yield return LoadScene("GameScene");

        yield return WaitFor(new ObjectAppeared<GameManager>());
        GameManager.Instance.Play();

        yield return WaitFor(new ObjectAppeared("Canvas/Layout Restrictor/Score/Player 1"));
        yield return WaitFor(new ObjectAppeared("Canvas/Layout Restrictor/Score/Player 2"));
        
        TMPro.TextMeshProUGUI playerScore1 = GameObject.Find("Canvas/Layout Restrictor/Score/Player 1").GetComponent<TMPro.TextMeshProUGUI>();
        TMPro.TextMeshProUGUI playerScore2 = GameObject.Find("Canvas/Layout Restrictor/Score/Player 2").GetComponent<TMPro.TextMeshProUGUI>();

        Assert.IsNotNull(playerScore1);
        Assert.IsNotNull(playerScore2);

        Assert.AreEqual(playerScore1.text, "0");
        Assert.AreEqual(playerScore2.text, "0");
    }

    [UnityTest]
    public IEnumerator TestIncreaseScorePlayer1()
    {
        yield return LoadScene("GameScene");

        yield return WaitFor(new ObjectAppeared<GameManager>());
        GameManager.Instance.Play();

        yield return WaitFor(new ObjectAppeared<BallController>());

        BallController ball = Object.FindObjectOfType<BallController>();
        ball.ballSpeed = new Vector2(0.75f, 0.25f);

        yield return WaitFor(new BoolCondition(() => ball.moving == true));
        yield return WaitFor(new BoolCondition(() => ball.moving == false));

        Assert.AreEqual(GameObject.Find("Canvas/Layout Restrictor/Score/Player 1").GetComponent<TMPro.TextMeshProUGUI>().text, "1");
        Assert.AreEqual(GameObject.Find("Canvas/Layout Restrictor/Score/Player 2").GetComponent<TMPro.TextMeshProUGUI>().text, "0");
    }

    [UnityTest]
    public IEnumerator TestIncreaseScorePlayer2()
    {
        yield return LoadScene("GameScene");

        yield return WaitFor(new ObjectAppeared<GameManager>());
        GameManager.Instance.Play();

        yield return WaitFor(new ObjectAppeared<BallController>());

        BallController ball = Object.FindObjectOfType<BallController>();
        ball.ballSpeed = new Vector2(-0.75f, 0.25f);

        yield return WaitFor(new BoolCondition(() => ball.moving == true));
        yield return WaitFor(new BoolCondition(() => ball.moving == false));

        Assert.AreEqual(GameObject.Find("Canvas/Layout Restrictor/Score/Player 1").GetComponent<TMPro.TextMeshProUGUI>().text, "0");
        Assert.AreEqual(GameObject.Find("Canvas/Layout Restrictor/Score/Player 2").GetComponent<TMPro.TextMeshProUGUI>().text, "1");
    }

    [UnityTest]
    public IEnumerator TestBounceAndGoalInFavorOfPlayer1()
    {
        yield return LoadScene("GameScene");

        yield return WaitFor(new ObjectAppeared<GameManager>());
        GameManager.Instance.Play();

        yield return WaitFor(new ObjectAppeared<BallController>());

        BallController ball = Object.FindObjectOfType<BallController>();
        ball.ballSpeed = new Vector2(-0.5f, 0.05f);

        yield return WaitFor(new BoolCondition(() => ball.moving == true));
        yield return WaitFor(new BoolCondition(() => ball.moving == false));

        Assert.AreEqual(GameObject.Find("Canvas/Layout Restrictor/Score/Player 1").GetComponent<TMPro.TextMeshProUGUI>().text, "1");
        Assert.AreEqual(GameObject.Find("Canvas/Layout Restrictor/Score/Player 2").GetComponent<TMPro.TextMeshProUGUI>().text, "0");
    }

    [UnityTest]
    public IEnumerator TestBounceAndGoalInFavorOfPlayer2()
    {
        yield return LoadScene("GameScene");

        yield return WaitFor(new ObjectAppeared<GameManager>());
        GameManager.Instance.Play();

        yield return WaitFor(new ObjectAppeared<BallController>());

        BallController ball = Object.FindObjectOfType<BallController>();
        ball.ballSpeed = new Vector2(0.5f, 0.05f);

        yield return WaitFor(new BoolCondition(() => ball.moving == true));
        yield return WaitFor(new BoolCondition(() => ball.moving == false));

        Assert.AreEqual(GameObject.Find("Canvas/Layout Restrictor/Score/Player 1").GetComponent<TMPro.TextMeshProUGUI>().text, "0");
        Assert.AreEqual(GameObject.Find("Canvas/Layout Restrictor/Score/Player 2").GetComponent<TMPro.TextMeshProUGUI>().text, "1");
    }
}
