using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CueDrag : MonoBehaviour
{
    //public StrikerMovement endpoint;
    public Slider dragSlider;
    public GameObject cue;
    // Start is called before the first frame update
    void Start()
    {
        //endpoint= GetComponent<StrikerMovement>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 force = StrikerMovement.rendpoint - StrikerMovement.startPoint;
        Debug.Log("rend"+StrikerMovement.rendpoint);
        Debug.Log("end" + StrikerMovement.endPoint);
        dragSlider.value = force.magnitude * 3f;
        //cue.transform.localPosition += new Vector3(0,0,Camera.main.transform.localPosition.z) * -force.magnitude;
        if (Input.GetMouseButton(0))
        {
            cue.transform.localPosition += new Vector3(cue.transform.localPosition.x, cue.transform.localPosition.y,
            -force.magnitude);
        }
        //Debug.Log(force.magnitude);
        //cue.transform.localPosition = cue.transform.localPosition + new Vector3(0,0, StrikerMovement.rendpoint.magnitude);
        //if (Input.GetMouseButton(0))
        //{
        //    cue.transform.localPosition = cue.transform.localPosition + new Vector3(transform.localPosition.x, transform.localPosition.y, -force.magnitude);
        //}
        //cue.transform.position = cue.transform.position + new Vector3(0,0, -force.magnitude);
    }
}
