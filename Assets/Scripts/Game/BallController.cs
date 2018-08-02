using UnityEngine;

public class BallController : MonoBehaviour
{
    public Vector2 ballSpeed;
    public float ballSpeedFactor = 0.5f;

    public bool moving = false;

    private void Start()
    {
        PutBackAtCenter();
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            Vector3 s3 = ballSpeed;
            transform.position += s3 * ballSpeedFactor;
        }
    }

    public void PutBackAtCenter()
    {
        moving = false;
        transform.position = new Vector3(0, 0, 0);
        ballSpeed = Random.insideUnitCircle;
    }
}
