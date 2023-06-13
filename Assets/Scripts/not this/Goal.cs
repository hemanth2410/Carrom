using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    // Start is called before the first frame update
    public GameController gameCon;
    int currentIndex;
    void Start()
    {
        currentIndex = gameCon.playerIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.GetComponent<Coin>()) 
        { 
            Destroy(other.gameObject);
        }
        if(currentIndex == 1)
        {
            gameCon.noOfPlayer1Turns++;
        }
        else if(currentIndex == 2) 
        {
            gameCon.noOfPlayer2Turns++;
        }
        
    }
}

