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
    bool strikerMoving;
    Rigidbody rb;
    void Start()
    {
        if(striker == null)
        {
            Debug.Log("dcgxsg");
        }
        striker = GameObject.FindGameObjectWithTag("Striker");
        GameManager.Instance.ApplyForce += Instance_ApplyForce;
        rb = GetComponent<Rigidbody>();
    }

    private void Instance_ApplyForce(Vector3 forceDirection, float forceMagnitude)
    {
        strikerMoving = true;
        rb.isKinematic = false;
        rb.AddForce(forceDirection *  forceMagnitude , ForceMode.Impulse);
        
    }
    private void FixedUpdate()
    {
        if (rb.velocity.magnitude <= 0.5f && strikerMoving)
        {
            rb.velocity = Vector3.zero;
            strikerMoving = false;
            GameManager.Instance.InvokeEnableCue();
        }
        if (setanglebool && !strikerMoving)
        {
            setangle();
        }
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
