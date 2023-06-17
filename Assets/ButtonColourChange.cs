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
    public static int counter = 0;

    public GameObject options;


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
            if(WhiteButtonScript.white == 1)
            {
                counter = 0;
                WhiteButtonScript.white = 0;
            }
            if (YellowButtonClick.yellow == 1)
            {
                counter = 1;
                YellowButtonClick.yellow = 0;
            }
            if (GreyButtonClick.Grey == 1)
            {
                counter = 3;
                GreyButtonClick.Grey = 0;
            }
            if (BlackButtonClick.Black == 1)
            {
                counter = 2;
                BlackButtonClick.Black = 0;
            }
            renderer.material = material1[counter];
            currentIndex = currentIndex + 1;
            if (currentIndex == 6)
            {
                options.SetActive(false);
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
