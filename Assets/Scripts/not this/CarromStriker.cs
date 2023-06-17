using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarromStriker : MonoBehaviour
{
    public float power = 10f;  // Power of the striker

    private Rigidbody rb;
    private Camera mainCamera;
    private bool isDragging = false;
    private Vector3 startPosition;
    private Vector3 endPosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    StartDragging();
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            EndDragging();
        }

        if (isDragging)
        {
            UpdateDraggingPosition();
        }
    }

    private void StartDragging()
    {
        isDragging = true;
        startPosition = GetMouseWorldPosition();
    }

    private void UpdateDraggingPosition()
    {
        endPosition = GetMouseWorldPosition();
    }

    private void EndDragging()
    {
        isDragging = false;
        Vector3 direction = (startPosition - endPosition).normalized;
        Vector3 force = direction * power;

        // Apply the force to the striker
        rb.AddForce(force, ForceMode.Impulse);
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -mainCamera.transform.position.z;
        return mainCamera.ScreenToWorldPoint(mousePosition);
    }
}
