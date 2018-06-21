using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    //Current score
    public int Score;
    //Score needed in order to win
    public int VictoryScore;

    void Start()
    {
        //Sets the value of VictoryScore to the number of objects with the 
        //PickupBehaviour component attached to them.
        VictoryScore = FindObjectsOfType<PickupBehaviour>().Length;
    }

    void Update()
    {
        //If Score is greater than or equal to VictoryScore the player wins.
        if (Score >= VictoryScore)
        {
            Debug.Log("You Win");
        }
    }
}
