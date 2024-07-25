using UnityEngine;

public class BottleScript : MonoBehaviour
{
    //public GameObject Bottle;
    public float forceAmount = 2.5f;  // Amount of force to apply per click
    public float xMovementAmount = 2.5f; // Amount of X-axis movement per click
    public float rotationSpeed = 360f; // Rotation speed in degrees per second
    private int clickCount = 0;      // Counter to track number of touches
    private bool isGrounded = false; // Flag to check if the bottle is grounded
    private bool isRotating = false; // Flag to check if the bottle is currently rotating
    private float rotationStartTime; // Time when rotation started
    private Quaternion startRotation; // Initial rotation when rotation starts
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //if (Bottle == null)
        //{
        //    Debug.LogError("Bottle GameObject is not assigned.");
        //}
    }

    void Update()
    {
        if (!isGrounded && rb.velocity.y < 0 && !isRotating)
        {
            transform.rotation = Quaternion.identity;
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                if (isGrounded || clickCount < 2)
                {
                    clickCount++;
                    if (clickCount == 1 && !isRotating)
                    {
                        // Apply upward and X-axis force, and start 360-degree rotation
                        ApplyForce(Vector3.up * forceAmount, Vector3.right * xMovementAmount);
                        StartRotation();
                    }
                    else if (clickCount == 2)
                    {
                        // Apply additional upward and X-axis force
                        ApplyForce(Vector3.up * forceAmount, Vector3.right * xMovementAmount);
                        StartRotation();
                    }
                }
            }
        }

        if (isRotating)
        {
            // Update the rotation
            float elapsedTime = Time.time - rotationStartTime;
            float rotationAmount = elapsedTime * rotationSpeed;

            if (rotationAmount >= 360f)
            {
                rotationAmount = 360f; // Ensure it does not exceed 360 degrees
                isRotating = false;   // Stop rotating
            }

            transform.rotation = startRotation * Quaternion.Euler(0, 0, -rotationAmount);
        }
    }

    void ApplyForce(Vector3 forceUpward, Vector3 forceX)
    {
        if (rb != null)
        {
            rb.velocity = Vector3.zero;  // Reset the velocity to avoid compounding forces
            rb.AddForce(forceUpward, ForceMode.Impulse);
            rb.AddForce(forceX, ForceMode.Impulse);
        }
    }

    void StartRotation()
    {
        startRotation = Quaternion.identity; // Start from the current rotation
        rotationStartTime = Time.time;
        isRotating = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Platform"))
        {
            isGrounded = true;
            clickCount = 0;  // Reset the click count when the bottle collides with the ground
            transform.rotation = Quaternion.identity;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Platform"))
        {
            isGrounded = false;
        }
    }
}
