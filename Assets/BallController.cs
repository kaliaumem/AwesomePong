using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {
    public Vector2 ballSpeed;
    public float ballSpeedFactor = 0.5f;

    private void Start()
    {
        ballSpeed = Random.insideUnitCircle;
    }

    // Update is called once per frame
    void Update () {
        Vector3 s3 = ballSpeed;
        transform.position += s3 * ballSpeedFactor;
	}
}
