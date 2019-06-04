using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rigidbodyRef;

    public float speed;    
	// Use this for initialization
	void Start ()
	{
        //Assigns a value to the rigidbody variable by grabbing a rigidbody
        //component that is attached to the same GameObject this script is
        //attached to.
        rigidbodyRef = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
	{
        //Gets a floating point value from the Input Manager for horizontal
        //and vertical movement and stores them in two variables that we will
        //use to move our player around.
	    float horizontal = Input.GetAxis("Horizontal");
	    float vertical = Input.GetAxis("Vertical");

        //Applies a force to the rigidbody attached to the player in a direction
        //determined by the values the Input manager is returning.
        rigidbodyRef.AddForce(new Vector3(horizontal,0,vertical) * speed);
        
        //Makes the object rotate in the direction we are traveling and if we are no longer moving set the object to look forward again
        if (horizontal != 0 || vertical != 0)
            transform.forward = rigidbodyRef.velocity;
        else
            transform.forward = Vector3.Lerp(transform.forward, Vector3.forward, Vector3.Distance(transform.forward, Vector3.forward) * (Time.deltaTime * speed));
	}
}
