using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    public float dragSpeed = 5f;
    public float slideAmount = 3f;
    public float maxYawAngle = 15f;

    private Vector3 lastMousePosition;
    private Vector3 startPos;
    private Quaternion startRotation;

    void Start()
    {
        startPos = transform.position;
        startRotation = transform.rotation;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - lastMousePosition;
            float move = -delta.x * dragSpeed * Time.deltaTime * 0.01f;

            // Slide camera
            Vector3 moveDir = transform.right * move;
            Vector3 newPos = transform.position + moveDir;

            // Clamp position along the right vector
            float distance = Vector3.Dot(newPos - startPos, transform.right);
            distance = Mathf.Clamp(distance, -slideAmount, slideAmount);

            // Move camera
            transform.position = startPos + transform.right * distance;

            // Calculate rotation based on movement amount
            float t = distance / slideAmount; // -1 to 1
            float targetYaw = maxYawAngle * t;

            Quaternion targetRot = Quaternion.Euler(
                startRotation.eulerAngles.x,
                startRotation.eulerAngles.y + targetYaw,
                startRotation.eulerAngles.z
            );

            transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, Time.deltaTime * 5f);

            lastMousePosition = Input.mousePosition;
        }
    }
}