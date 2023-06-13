using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikerMovement : MonoBehaviour
{
    public float power = 10f;  // Power of the striker
    public float maxDragDistance = 2f;  // Maximum distance the striker can be dragged

    public Rigidbody rb;
    //public Rigidbody cb;
    private Vector3 startPoint;
    private Vector3 endPoint;
    private Vector3 force;
    public LayerMask BOARD;

    private float dragDistance;
    public float maxDragAngle = 45f;
    private Quaternion startRotation;

    public GameObject cue;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        //cb = GetComponent<Rigidbody>();
        startRotation = transform.rotation;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPoint = GetMousePosition();
        }

        //if (Input.GetMouseButton(0))
        //{
            

        //}

        if (Input.GetMouseButtonUp(0))
        {
            endPoint = GetMousePosition();
            DragStriker();
            ShootStriker();
        }
    }

    private Vector3 GetMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit,BOARD))
        {
            return hit.point;
        }
        else
        {
            return Vector3.zero;
        }
    }

    private void DragStriker()
    {
        float distance = Vector3.Distance(startPoint, endPoint);
        distance = Mathf.Clamp(distance, 0f, maxDragDistance);

        force = (endPoint - startPoint).normalized * distance * power;

        float dragAngle = Mathf.Clamp(distance / maxDragDistance, 0f, 1f) * maxDragAngle;

        // Adjust the position of the striker during dragging
        //rb.MovePosition(startPoint + force * Time.deltaTime);
        //rb.MovePosition(startPoint);
        //cue.transform.localPosition = transform.localPosition + endPoint;
        rb.MovePosition(startPoint + force * Time.deltaTime);
        rb.MoveRotation(startRotation * Quaternion.Euler(Vector3.up * dragAngle));

        //cue.transform.localRotation = 
    }

    private void ShootStriker()
    {
        rb.AddForce(-force, ForceMode.Impulse);
    }
}
