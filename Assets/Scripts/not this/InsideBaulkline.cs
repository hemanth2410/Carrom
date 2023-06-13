using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideBaulkline : MonoBehaviour
{
    public static int baulkline;
    // Start is called before the first frame update
    void Start()
    {
        baulkline= 0;  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "baulk line")
        {
            baulkline = 1;
        }
    }

    private void OnTriggerExit(Collider other)
    {
       baulkline = 0;
    }
}
