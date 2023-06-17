using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class rotateboard : MonoBehaviour
{
    public GameObject striker;
    public Slider rotateslider;

    [SerializeField] float angle;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        angle = rotateslider.value * 360f;
        this.transform.rotation = Quaternion.Euler(0, angle, 0);
    }
}
