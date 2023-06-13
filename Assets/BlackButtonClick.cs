using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackButtonClick : MonoBehaviour
{
    // Start is called before the first frame update
    public static int Black = 0;
    void Start()
    {

        gameObject.GetComponent<Button>().onClick.AddListener(colourchange);
    }

    // Update is called once per frame
    public void colourchange()
    {
        Black = 1;
    }
}
