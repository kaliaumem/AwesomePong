using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void FlipBallDirection(bool isXAxis)
    {
        GameObject ball = GameObject.Find("ball");
        if(ball != null)
        {
            BallController ballController = ball.GetComponent<BallController>();
            if(ballController != null)
            {
                if(isXAxis)
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
}
