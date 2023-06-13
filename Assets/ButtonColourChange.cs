using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColourChange : MonoBehaviour
{
    //public GameObject coin;
    //private Renderer coinRenderer;
    public Material material1;
    public Color[] newColor;
    private int currentIndex = 0;


    public void Start()
    {
        //coinRenderer =  coin.GetComponent<Renderer>();
        gameObject.GetComponent<Button>().onClick.AddListener(changecoloronclick);
    }
    public void changecoloronclick()
    {
        material1.color = newColor[currentIndex];
        //coinRenderer.material.color = newColor[currentIndex];
        currentIndex = (currentIndex + 1) % newColor.Length;
        if(currentIndex == 4)
        {
            currentIndex= 0;
        }
    }
}
