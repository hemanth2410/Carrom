////using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CueControl : MonoBehaviour
{
    Vector3 currentRotation;
    Vector3 TargetRotation;
    [SerializeField] float m_sensitivity;
    [SerializeField] Transform m_CueStick;
    [SerializeField] float m_maxPullDistance;
    [SerializeField] Slider m_pullBackSlider;
    [SerializeField] GameObject m_Striker;
    [SerializeField] float m_maxMagnitude;
    [SerializeField] GameObject m_CueMesh;
    [SerializeField] bool primed = false;
    [SerializeField] bool returned = false;
    [SerializeField] Vector3 targetVector;
    [SerializeField] Vector3 targetPoint;
    LineRenderer lineRenderer;
    float previousValue;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.EnableCue += Instance_EnableCue;
        lineRenderer = GetComponentInChildren<LineRenderer>();
    }

    private void Instance_EnableCue()
    {
        m_CueMesh.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && !GameManager.Instance.CueLocked)
        {
            // handle code here when left mouse is held
            float _mouseX = Mathf.Clamp(Input.GetAxis("Mouse X"),-0.5f,0.5f);
            float _mouseY = Mathf.Clamp(Input.GetAxis("Mouse Y"),-0.5f,0.5f);
            currentRotation = transform.rotation.eulerAngles;
            TargetRotation = new Vector3(currentRotation.x + (-_mouseY * m_sensitivity), currentRotation.y + (-_mouseX * m_sensitivity), 0);
            transform.rotation = Quaternion.Euler(TargetRotation);
        }
        m_CueStick.position = (-m_CueStick.forward * Mathf.Lerp(0, m_maxPullDistance, m_pullBackSlider.value)) + m_Striker.transform.position;
        lineRenderer.SetPosition(0, m_Striker.transform.position);
        targetVector = m_CueStick.forward * m_maxPullDistance * m_pullBackSlider.value;
        targetPoint = new Vector3(targetVector.x , m_Striker.transform.position.y, targetVector.z);
        lineRenderer.SetPosition(1, targetPoint);
        // now check if cue is primed and ready to strike;
        if (primed && returned)
        {
            primed = false;
            returned = false;
            GameManager.Instance.InvokeForceApplied(m_CueStick.forward, m_maxMagnitude * previousValue);
            m_CueMesh.SetActive(false);
            previousValue = 0.0f;
        }
    }
    public void EvaluateMaximumPull()
    {
        if(previousValue < m_pullBackSlider.value)
        {
            previousValue = m_pullBackSlider.value;
        }
        if(previousValue > 0.2f)
        {
            primed = true;
        }
        if(primed && m_pullBackSlider.value < 0.1f)
        {
            returned = true;
        }
    }
}
