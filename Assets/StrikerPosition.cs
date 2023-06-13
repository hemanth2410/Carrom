using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class StrikerPosition : MonoBehaviour
{
    public Slider strikerpos;
    public GameObject centralPoint;
    public float radius = 7f;
    public float angle;
    public float startpos = 0.3f;
    public bool setanglebool = true;
    public Striker lr;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (setanglebool)
        {
            setangle();
        }

        //freezepos.onClick.AddListener(OnClickButton);
    }

    void setangle()
    {
        angle = strikerpos.value;
        //angle = Mathf.Clamp(angle, 0, 1f);
        float xPos = centralPoint.transform.position.x + (radius * Mathf.Sin(angle));
        float yPos = centralPoint.transform.position.z + (radius * Mathf.Cos(angle));
        transform.position = new Vector3(xPos, transform.position.y, yPos);
        lr.aimLine.enabled = false;
    }


    public void DisableScript()
    {
        enabled= false;
    }


    public void DisableScript3()
    {
        enabled = true;
    }
    /*private void OnClickButton()
    {
        setanglebool= false;
    }*/
}
