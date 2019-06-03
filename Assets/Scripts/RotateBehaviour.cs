using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBehaviour : MonoBehaviour
{
    //Direction the object will rotate on the X Axis
    [Range(-1,1)]
    public int xRotate;
    //Direction the object will rotate on the Y Axis
    [Range(-1, 1)]
    public int yRotate;
    //Direction the object will rotate on the Z Axis
    [Range(-1, 1)]
    public int zRotate;

    //How Fast the object will rotate
    public float RotateSpeed;

	// Update is called once per frame
	void Update ()
	{
        //Rotates the objects on it's 3 axes based ont the values of
        //xRotate, yRotate, zRotate.
	    transform.Rotate(new Vector3(xRotate, yRotate, zRotate) * RotateSpeed);	
	}
}
