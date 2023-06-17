using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enablecoincolorchange : MonoBehaviour
{
    public GameObject options1;
    // Start is called before the first frame update
    void Start()
    {
        options1.SetActive(false);
        gameObject.GetComponent<Button>().onClick.AddListener(enableoptions);
    }

    // Update is called once per frame
    public void enableoptions()
    {
        options1.SetActive(true);
    }
}
