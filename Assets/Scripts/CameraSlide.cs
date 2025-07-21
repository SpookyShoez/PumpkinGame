using UnityEngine;

public class CameraSlide : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float minX = -3f;
    public float maxX = 3f;

    private Vector3 targetPosition;

    void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        float input = Input.GetAxisRaw("Horizontal");

        // Move only if there's input
        if (Mathf.Abs(input) > 0.1f)
        {
            targetPosition += new Vector3(input * moveSpeed * Time.deltaTime, 0, 0);
            targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX);
        }

        // Smooth transition
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 10f);
    }
}
