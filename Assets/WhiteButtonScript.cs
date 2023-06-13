using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhiteButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static int white = 0;
    void Start()
    {
        
        gameObject.GetComponent<Button>().onClick.AddListener(colourchange);
    }

    // Update is called once per frame
    public void colourchange()
    {
        white = 1;
    }
}
