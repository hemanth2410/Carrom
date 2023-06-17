using System.Collections;
using System.Collections.Generic;
using System.Net;
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
    public GameObject striker;
    public StrikerMovement ED;

    void Start()
    {
        if(striker == null)
        {
            Debug.Log("dcgxsg");
        }
        striker = GameObject.FindGameObjectWithTag("Striker");
    }

    // Update is called once per frame
    void Update()
    {

        //if (Input.GetMouseButtonDown(0))
        //{
        //    ED.DisableScript();
        //}

        //if (Input.GetMouseButtonUp(0))
        //{
        //    StartCoroutine("waitfor3sec");
        //    ED.EnableScript3();
        //}
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
        //striker.GetComponent<Striker>().aimLine.enabled = false;
    }


    public void DisableScript()
    {
        enabled= false;
    }


    public void EnableScript3()
    {
        enabled = true;
    }
    /*private void OnClickButton()
    {
        setanglebool= false;
    }*/

    //IEnumerator waitfor3sec()
    //{
    //    yield return new WaitForSeconds(3f);
    //}
}
