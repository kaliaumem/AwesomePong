using UnityEngine;

public enum PaddleSide { LEFT, RIGHT };

public class Paddle : MonoBehaviour
{

    // enum to use the correct input names depending on the side the paddle is on
    [SerializeField] private PaddleSide Side;
    [SerializeField] private float Speed = 0.2f;

    private Vector3 direction = Vector3.zero;
    private Vector3 tmpPosition;
    private string input;

    // Set the input name to use
    private void Awake()
    {
        input = (Side == PaddleSide.LEFT) ? "Left Paddle" : "Right Paddle";
    }

    // Handle the input then move the paddle if not too high nor too low
    private void Update()
    {
        direction.y = Input.GetAxis(input);

        tmpPosition = transform.position + direction * Speed;
        if (tmpPosition.y <= 4.0 && tmpPosition.y >= -4.0)
            transform.position += direction * Speed;
    }
}
