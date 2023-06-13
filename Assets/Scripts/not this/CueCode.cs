using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueCode : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject cue;
    public Rigidbody cueBall;
    public float maxForce = 10f;
    public float forceMultiplier = 2f;

    private bool isDragging = false;
    private Vector3 dragStartPos;
    private Vector3 dragEndPos;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    isDragging = true;
                    dragStartPos = hit.point;
                }
            }
        }

        if (isDragging)
        {
            if (Input.GetMouseButton(0))
            {
                cue.SetActive(true);
                RaycastHit hit;
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    dragEndPos = hit.point;
                    Vector3 forceDirection = (dragEndPos - dragStartPos).normalized;
                    float dragDistance = Vector3.Distance(dragEndPos, dragStartPos);
                    float clampedDistance = Mathf.Clamp(dragDistance * forceMultiplier, 0f, maxForce);
                    cueBall.AddForce(forceDirection * clampedDistance, ForceMode.Impulse);
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                isDragging = false;
                cue.SetActive(false);
            }
        }
    }
}
