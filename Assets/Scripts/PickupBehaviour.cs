using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBehaviour : MonoBehaviour
{
    //If an object comes enters the trigger volume of the object
    //this script is attached to this function will be invoked.
    private void OnTriggerEnter(Collider other)
    {
        //If the object that entered the trigger volume has a ScoreKeeper
        //component attached to it we will increase the value of the Score
        //variable by 1
        if (other.GetComponent<ScoreKeeper>())
        {
            other.GetComponent<ScoreKeeper>().Score++;
            //Destroys the object this script is attached to
            Destroy(this.gameObject);
        }
    }
}
