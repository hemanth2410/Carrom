using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarromCue : MonoBehaviour
{
    public Camera mainCamera; // Reference to the main camera
    public float maxCueDistance = 5f; // Maximum distance the cue can be dragged
    public float maxForce = 10f; // Maximum force to be applied to the cue ball
    public LayerMask ballLayer; // Layer mask for the billiard balls

    private bool isDragging = false; // Flag to indicate if the cue is being dragged
    private Vector3 initialPosition; // Initial position of the cue
    private Rigidbody cueRigidbody; // Reference to the cue's Rigidbody component

    private float cueBallDistance; // Distance between the cue and the cue ball
    private Vector3 hitDirection; // Direction to hit the cue ball

    void Start()
    {
        cueRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isDragging)
        {
            // Cast a ray from the camera to the play surface
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Calculate the direction from the cue to the hit point
                Vector3 direction = hit.point - transform.position;
                direction.y = 0f; // Keep the cue pointing horizontally

                // Rotate the cue to face the hit point
                transform.rotation = Quaternion.LookRotation(-direction);

                // Calculate the force based on the distance
                float distance = Mathf.Clamp(direction.magnitude, 0f, maxCueDistance);
                float force = distance / maxCueDistance * maxForce;

                // Update the cue ball distance and hit direction
                cueBallDistance = distance;
                hitDirection = direction.normalized;

                // Apply force to the cue ball
                if (Input.GetMouseButtonUp(0))
                {
                    Rigidbody ballRigidbody = hit.collider.GetComponent<Rigidbody>();
                    ballRigidbody.AddForce(hitDirection * force, ForceMode.Impulse);
                }
            }
        }
    }

    void FixedUpdate()
    {
        if (isDragging)
        {
            // Update the cue position based on the mouse movement
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            Vector3 newPosition = ray.GetPoint(cueBallDistance);
            cueRigidbody.MovePosition(newPosition);
        }
    }

    void OnMouseDown()
    {
        isDragging = true;
        initialPosition = transform.position;
    }

    void OnMouseUp()
    {
        isDragging = false;
        cueRigidbody.velocity = Vector3.zero;
        transform.position = initialPosition;
        transform.rotation = Quaternion.identity;
    }
}
