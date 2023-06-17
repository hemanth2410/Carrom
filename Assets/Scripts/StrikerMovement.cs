using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    public StrikerPosition switch0;

    public GameObject cue;

    private void Start()
    {
        //cue.transform.localPosition = transform.localPosition;
        rb = GetComponent<Rigidbody>();
        //cb = GetComponent<Rigidbody>();
        startRotation = transform.rotation;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            cue.gameObject.SetActive(true);
            switch0.EnableScript3();

            startPoint = GetMousePosition();
        }

        //if (Input.GetMouseButton(0))
        //{
        //    //switch0.DisableScript();

        //}

        if (Input.GetMouseButtonUp(0))
        {
            
            endPoint = GetMousePosition();
            DragStriker();
            ShootStriker();
            //switch0.EnableScript3();
            
            
        }

        //cue.transform.localPosition = cue.transform.localPosition + new Vector3(0,0, endPoint.z);
    }

    private Vector3 GetMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit,100f,BOARD))
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

        switch0.DisableScript();

        // Adjust the position of the striker during dragging
        //rb.MovePosition(startPoint + force * Time.deltaTime);
        //rb.MovePosition(startPoint);
        //cue.transform.localPosition = transform.localPosition + endPoint;
        //rb.MovePosition(startPoint + force * Time.deltaTime);
        //rb.MoveRotation(startRotation * Quaternion.Euler(Vector3.up * dragAngle));


    }

    private void ShootStriker()
    {
        Debug.Log("shootstrikerinside");
        rb.AddForce(-Camera.main.transform.forward * force.z * 10f, ForceMode.Impulse);
        cue.gameObject.SetActive(false);
        
    }

    //public void DisableScript()
    //{
    //    enabled = false;
    //}


    //public void EnableScript3()
    //{
    //    enabled = true;
    //}
}
