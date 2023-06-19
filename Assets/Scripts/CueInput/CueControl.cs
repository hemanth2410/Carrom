using System.Collections;
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            // handle code here when left mouse is held
            float _mouseX = Mathf.Clamp(Input.GetAxis("Mouse X"),-0.5f,0.5f);
            float _mouseY = Mathf.Clamp(Input.GetAxis("Mouse Y"),-0.5f,0.5f);
            currentRotation = transform.rotation.eulerAngles;
            TargetRotation = new Vector3(currentRotation.x + (_mouseY * m_sensitivity), currentRotation.y + (-_mouseX * m_sensitivity), 0);
            transform.rotation = Quaternion.Euler(TargetRotation);
        }
        m_CueStick.position = -m_CueStick.forward * Mathf.Lerp(0, m_maxPullDistance, m_pullBackSlider.value);
    }
}
