using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{


    public float sensitivity = 1f;



    private void Start()
    {
       // Cursor.lockState = CursorLockMode.Locked;
       // Cursor.visible = false;

    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;
        float mx = Mathf.Clamp(mouseX,-0.1f,0.1f);
        //float my = Mathf.Clamp(mouseY,-0.1f,0.1f);
        Vector3 movement = new Vector3(mx, 0f, 0f);
        transform.Translate(movement);


        if (Input.GetKey(KeyCode.F))
        {

            transform.Translate(0,0,0.01f);
        }
        if (Input.GetKey(KeyCode.G))
        {

            transform.Translate(0, 0, -0.01f);
        }
    }
}
