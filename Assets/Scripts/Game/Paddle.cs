using UnityEngine;

public class Paddle : MonoBehaviour
{
    enum PaddleSide { LEFT, RIGHT };

    // enum to use the correct input names depending on the side the paddle is on
    [SerializeField] private PaddleSide Side;
    [SerializeField] private float Speed = 0.2f;

    private Vector3 direction = Vector3.zero;
    private Vector3 tmpPosition;
    private string upInput;
    private string downInput;

    // Set the input names to use
    private void Awake()
    {
        upInput = (Side == PaddleSide.LEFT) ? "Left Up" : "Right Up";
        downInput = (Side == PaddleSide.LEFT) ? "Left Down" : "Right Down";
    }

    // Handle the inputs then move the paddle if not too high or low
    private void Update()
    {
        if (Input.GetButtonDown(upInput))
            direction = new Vector3(0.0f, 1.0f, 0.0f);
        else if (Input.GetButtonDown(downInput))
            direction = new Vector3(0.0f, -1.0f, 0.0f);
        else if (Input.GetButtonUp(upInput) || Input.GetButtonUp(downInput))
            direction = Vector3.zero;

        tmpPosition = transform.position + direction * Speed;
        if (tmpPosition.y <= 4.0 && tmpPosition.y >= -4.0)
            transform.position += direction * Speed;
    }
}
