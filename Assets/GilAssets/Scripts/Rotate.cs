using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]private float speed = 2.0f;
    public string direction;

    private void Update()
    {
        switch (direction)
        {
            case "normal":
                transform.Rotate(Vector3.up, 10.0f * (speed * Time.deltaTime));
                break;
            case "vertical":
                transform.Rotate(Vector3.right, 10.0f * (speed * Time.deltaTime));
                break;
            case "sideways":
                transform.Rotate(Vector3.back, 10.0f * (speed * Time.deltaTime));
                break;
            default:
                transform.Rotate(Vector3.up, 10.0f * (speed * Time.deltaTime));
                break;
        }

    }
}
