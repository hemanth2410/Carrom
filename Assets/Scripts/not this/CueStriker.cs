using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueStriker : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject cue;
    public GameObject cueBall;

    private bool isAiming = false;
    private RaycastHit hit;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isAiming)
            {
                // Start aiming
                isAiming = true;
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    // Ensure the raycast hits the cue ball
                    if (hit.collider.gameObject == cueBall)
                    {
                        cue.SetActive(true);
                        cue.transform.position = hit.point;
                        cue.transform.LookAt(cueBall.transform);
                    }
                }
            }
            else
            {
                // Fire cue ball
                isAiming = false;
                cue.SetActive(false);
                if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit))
                {
                    // Ensure the raycast hits the cue ball
                    if (hit.collider.gameObject == cueBall)
                    {
                        Rigidbody rb = cueBall.GetComponent<Rigidbody>();
                        rb.AddForce(mainCamera.transform.forward * 1000f);
                    }
                }
            }
        }
    }
}
