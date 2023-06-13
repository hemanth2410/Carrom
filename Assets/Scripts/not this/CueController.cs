using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueController : MonoBehaviour
{
    public Transform cueBall;
    public Transform cue;
    public float forceMultiplier = 10f;

    private bool isPullingCue = false;
    private Vector3 cueStartPos;
    private Rigidbody cueRigidbody;

    void Start()
    {
        cueRigidbody = cue.GetComponent<Rigidbody>();
        cueStartPos = cue.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == cue)
                {
                    isPullingCue = true;
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (isPullingCue)
            {
                isPullingCue = false;
                ShootCue();
            }
        }

        if (isPullingCue)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Vector3.Distance(Camera.main.transform.position, cue.position);
            cue.position = Camera.main.ScreenToWorldPoint(mousePos);
        }
    }

    void ShootCue()
    {
        Vector3 forceDirection = cueBall.position - cue.position;
        forceDirection.Normalize();
        cueRigidbody.AddForce(forceDirection * forceMultiplier, ForceMode.Impulse);

        // Reset the cue position
        cue.position = cueStartPos;
    }
}
