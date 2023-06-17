using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisableScript : MonoBehaviour
{
    public StrikerMovement EDD;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            EDD.DisableScript();
        }

        if (Input.GetMouseButtonUp(0))
        {
            StartCoroutine("waitfor3sec");
            EDD.EnableScript3();
        }
    }

    IEnumerator waitfor3sec()
    {
        yield return new WaitForSeconds(3f);
    }
}
