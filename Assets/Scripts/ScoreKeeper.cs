using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    //Current score
    public int Score;
    //Score needed in order to win
    public int VictoryScore;
    public Text ScoreVisual;
    public Text VictoryDisplay;

    void Start()
    {
        //Sets the value of VictoryScore to the number of objects with the 
        //PickupBehaviour component attached to them.
        VictoryScore = FindObjectsOfType<PickupBehaviour>().Length;
    }

    void Update()
    {
        //Will update the text information of UI score element to display the
        //player's current score.
        ScoreVisual.text = "Score: " + Score;
        //If Score is greater than or equal to VictoryScore the player wins.
        if (Score >= VictoryScore)
        {
            VictoryDisplay.gameObject.SetActive(true);
        }
    }
}
