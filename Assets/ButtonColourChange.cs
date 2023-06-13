using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColourChange : MonoBehaviour
{
    //public GameObject[] coin;
    //private Renderer coinRenderer;
    public Material[] material1;
    public Color[] newColor;
    private int currentIndex = 0;
    public int counter = 0;


    public void Start()
    {
        //coinRenderer = coin[0].GetComponent<Renderer>();
        //coinRenderer = coin[1].GetComponent<Renderer>();
        //coinRenderer = coin[2].GetComponent<Renderer>();
        //coinRenderer = coin[3].GetComponent<Renderer>();
        //coinRenderer = coin[4].GetComponent<Renderer>();
        //coinRenderer = coin[5].GetComponent<Renderer>();
        gameObject.GetComponent<Button>().onClick.AddListener(changecoloronclick);
    }
    public void changecoloronclick()
    {
        //material1.color = newColor[currentIndex];
        //coinRenderer.material.color = newColor[currentIndex];
        //coinRenderer.material = material1;
        //currentIndex = (currentIndex + 1) % newColor.Length;
        //if(currentIndex == 4)
        //{
        //    currentIndex= 0;
        //}
        GameObject[] objectsToChange = GameObject.FindGameObjectsWithTag("player1coin"); // Replace "YourTag" with the actual tag of the objects you want to change

        foreach (GameObject obj in objectsToChange)
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            renderer.material = material1[counter];
            currentIndex = currentIndex + 1;
            if (currentIndex == 6)
            {
                currentIndex = 0;
                counter = counter + 1;
                if(counter == 4)
                {
                    counter = 0;
                }
            }
        }
    }
}
