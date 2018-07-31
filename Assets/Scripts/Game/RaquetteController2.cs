using UnityEngine;

public class RaquetteController2 : MonoBehaviour
{

    public float Speed;

    Vector3 direction;

    // Use this for initialization
    void Start()
    {
        direction = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            direction = new Vector3(0, 1, 0);
        }
        else if (Input.GetKeyDown(KeyCode.S))
            direction = new Vector3(0, -1, 0);
        else if (Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp(KeyCode.S))
            direction = new Vector3(0, 0, 0);

        Vector3 newPosition = transform.position + direction * Speed;
        if (newPosition.y <= 4.0 && newPosition.y >= -4.0)
            transform.position += direction * Speed;
    }
}
