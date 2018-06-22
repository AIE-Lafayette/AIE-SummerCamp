# Roll-A-Ball

***

## Overview

[Roll-A-Ball](https://unity3d.com/learn/tutorials/s/roll-ball-tutorial)
This tutorial will cover the basics of using the Unity3D Engine to create a simple game. The game will have the user move a ball around a play area and collect pick-up items. Once all the pick-up items have been collected the game will let the user know they have won.

## Requirements

Unity3D installed  
Visual Studio 2015 or later  
Headphones (For students who choose to watch the videos instead)

## Getting Started

**1. Create a new Unity Project called Roll-A-Ball and save it in your assigned folder on the Desktop.**  
**2. Create a new Unity Scene name it 0.main**  
**3. Add a new plane object to the scene and scale it's X and Y values to 5**  
**4. Create a new cube and scale it's X value to 5. Then move to to line up with the edge of your plane.**  
**5. Duplicate the cube you just create and place it on the opposite side of the plane.**  
**6. Repeat Steps 4 and 5, but this time scale it's Z value to 5.**  
**7. Create 2 new materials one named Red and the other named Blue. Set the Albedo of those material to match the name.**  
**8. Using the new materials change the color of the plane red and the cubes blue by dragging the materials on to them in the scene view.**  
**9. Create a new sphere and place it in the middle of the plane and set it's Y position to 0.5.**  
**10. Create a new script name PlayerMovement.cs. This script will be responsible for moving our player around our playspace**  
```C#

public class PlayerMovement : MonoBehaviour
{
public Rigidbody rigidbody;

public float speed;
// Use this for initialization
void Start ()
{
    //Assigns a value to the rigidbody variable by grabbing a rigidbody
    //component that is attached to the same GameObject this script is
    //attached to.
    rigidbody = GetComponent<Rigidbody>();
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
    rigidbody.AddForce(new Vector3(horizontal,0,vertical) * speed);
}
}

```  

**11. Attach a Rigidbody component and the PlayerMovement script to the sphere.**  
**12. Set some value other than 0 in the input box for the value of Speed. Give your project a run and use the WASD keys to move the sphere around.**  
**14. Create a new cube in the scene and name it Pick-up. Then create a new yellow material and attach it to the new Pick-up object.**  
**15. Create a new script called RotateBehaviour. This script will allow us to rotate the object it is attached to while the game is running.**  

```C#

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

```  

**16. Attach the RotateBehaviour script to the Pick-up object. Modify the sliders for the values of the rotate variables and give some value for the speed variable. Press play and you should see the Pick-up object begin to rotate.**  
**17. Create a new script named PickupBehaviour. This script will turn off the object it is attached to win the player comes in contact with it. Create another script called ScoreKeeper. This script will keep track of how many Pick-up objects the player has picked up.**  

```C#

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

```  

```C#

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

```  

**18. Attach the PickupBehaviour script to the Pick-up object. In the Box Collider component attached to the Pick-up object check the box next to the variable IsTrigger.**  
**19. Attach the ScoreKeeper script to the Sphere object. Press play and move your Sphere over the Pick-up and it should get destroyed. The console should also display you win.**  
**20.Create a new UI text element and name it score. Place it in the top right corner of the canvas. Assign the text value to be "Score: ". Set the value of the Best Fit variable to be true. Create another UI text element that is parented to the canvas in the scene and name it GameOver. Set it's text to "Victory!" and set Best Fit to true. Set the GameOver active state to false.**  
**21. Modify the ScoreKeeper script to allow the game to display the player's score and let the player know when they have won.**  

```C#

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

```

**22. In the ScoreKeeper component attached to the Sphere object and assign the value of ScoreVisual the Score object. Assign the value of VictoryDisplay the GameOver object. Run the game and once you collect all the Pick-up objects the Victory text should display.**  
**23. Set the camera's position to (0,20,0) and set it's X rotation to 90**  
**24. Duplicate the Pick-up object and place the duplicates around play space.**  
**25. Build the application to an execuatable. Run execuatable from save location.**  