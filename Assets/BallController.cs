using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {
    private Vector2 ballSpeed;

    private void Start()
    {
        ballSpeed = Random.insideUnitCircle;
    }

    // Update is called once per frame
    void Update () {
        Vector3 s3 = ballSpeed;
        transform.position += s3;
	}
}
