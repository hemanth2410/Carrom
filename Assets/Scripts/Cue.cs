using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

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
    public Slider CueSlider;
    public float MaxPullBack = 2f;
    Rigidbody rb;
    bool forceApplied = false;
    float mousex;
    float mousey;
    Transform cueStick;
    [SerializeField] float m_MaxPullbackDistance;
    float currentPullback;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cueStick = transform.GetChild(0);
        //striker = GameObject.FindGameObjectWithTag("Striker");
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

            Vector3 currentRot = transform.rotation.eulerAngles;
            Vector3 targetRot = new Vector3(currentRot.x + (my * 10f), currentRot.y + (-mx * 10f), 0f);
            transform.rotation =  Quaternion.Euler(targetRot);

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


        //var cueStickPos = cueStick.localPosition;
        //float cueStickX = Mathf.Lerp(MaxPullBack, 0, CueSlider.value);
        //Debug.Log(cueStickPos);
        //cueStick.localPosition = new Vector3(cueStickX, cueStickPos.y, cueStickPos.z);
        //
        currentPullback = Mathf.Lerp(m_MaxPullbackDistance, 0, CueSlider.value);
        //cueStick.localPosition = cueStick.right * currentPullback;
        Debug.DrawLine(cueStick.position, cueStick.transform.right * 1.0f, Color.blue);
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
