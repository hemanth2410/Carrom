using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public int noOfPlayer1Turns = 1;
    public int noOfPlayer2Turns = 0;
    public int playerIndex = 1; 
    public GameObject player1Txt;
    public GameObject player2Txt;
    public bool isPlayer1Turn;
    void Start()
    {
        isPlayer1Turn = true;
        player2Txt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayer1Turn)
        {
            player1Txt.SetActive(true);
            player2Txt.SetActive(false);
        }
        else if(!isPlayer1Turn)
        {
            player1Txt.SetActive(false);
            player2Txt.SetActive(true); 
        }
    }
}
