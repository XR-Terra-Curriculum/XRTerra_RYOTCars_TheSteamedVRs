using UnityEngine;

public class Rotate : MonoBehaviour
{
    private float speed = 2.0f;
    private void Update()
    {
        transform.Rotate(Vector3.up, 10.0f *(speed * Time.deltaTime));
    }
}
