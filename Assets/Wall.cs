using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {
    public bool isHorizontal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Miaou");
        if (isHorizontal)
            GameManager.Instance.FlipBallDirection(false);
        else
            GameManager.Instance.FlipBallDirection(true);
    }
}
