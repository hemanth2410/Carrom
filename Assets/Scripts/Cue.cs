using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using UnityEngine;

public class Cue : MonoBehaviour
{
    Vector3 startPoint;
    Vector3 endPoint;

    public float power = 10f;  // Power of the striker
    public float maxDragDistance = 2f;
    public float speed = 1f;
    public float t = 0f;

    public Vector3 force;

    public GameObject striker;
    public Vector3 offset;
    Rigidbody rb;
    bool forceApplied = false;
    float mousex;
    float mousey;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        striker = GameObject.FindGameObjectWithTag("Striker");
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    startPoint = GetMousePosition();
        //}

        //if (Input.GetMouseButton(0))
        //{
        //    endPoint = GetMousePosition();
        //    DragCue();
        //}

        //if (Input.GetMouseButtonUp(0))
        //{
            
        //    ShootCue();
        //}
        

        if (Input.GetMouseButton(0))
        {
            forceApplied = true;
            mousex = Input.GetAxis("Mouse X") * 1f;
            mousey = Input.GetAxis("Mouse Y") * 1f;

            float mx = Mathf.Clamp(mousex, -0.5f, 0.5f);
            float my = Mathf.Clamp(mousey, -0.5f, 0.5f);

            transform.rotation = Quaternion.Euler(my * 10f, mx * 10f, 0f);

        }

        if (Input.GetMouseButtonUp(0))
        {
            forceApplied = false;
        }

        else if (!forceApplied)
        {
            transform.position = striker.transform.position;
            //forceApplied = true;
        }
        
    }

    private Vector3 GetMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            return hit.point;
        }
        else
        {
            return Vector3.zero;
        }
    }

    private void DragCue()
    {
        float distance = Vector3.Distance(startPoint, endPoint);
        distance = Mathf.Clamp(distance, 0f, maxDragDistance);

        force = (endPoint - startPoint).normalized * distance * power;

        //rb.MovePosition(endPoint + force * Time.deltaTime);
    }

    private void ShootCue()
    {
        t += speed * Time.deltaTime;

        // Ensure the interpolation factor stays within 0 to 1
        t = Mathf.Clamp01(t);

        // Interpolate between the start and end points
        startPoint = Vector3.Lerp(endPoint, startPoint, 0.2f);
        //transform.position = startPoint;
    }
}
