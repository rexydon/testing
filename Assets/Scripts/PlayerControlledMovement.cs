using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlledMovement : MonoBehaviour {


    public float speedForce = 4.0f; // move speed of object
    public float minHeldDown = 0.01f;
    public float maxHeldDown = 1.0f;
    public float constrainDistant = 5.0f;
    public float heldDown = 0.0f;
    public bool BallInMotion = false;
    public char keyPressed = ' ';
    Vector3 movementDirection = Vector3.zero;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //TODO:
        //Cause the ball to move when the arrow keys are pressed
        

        //HARD CHALLENGE
        if (Input.GetKeyDown(KeyCode.W))
        {
            movementDirection = Vector3.zero;
            BallInMotion = false;
            heldDown = 0.0f;
            keyPressed = 'W';
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            movementDirection = Vector3.zero;
            BallInMotion = false;
            heldDown = 0.0f;
            keyPressed = 'A';
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            movementDirection = Vector3.zero;
            BallInMotion = false;
            heldDown = 0.0f;
            keyPressed = 'S';
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            movementDirection = Vector3.zero;
            BallInMotion = false;
            heldDown = 0.0f;
            keyPressed = 'D';
        }
        if (Input.GetKey(KeyCode.W) && keyPressed == 'W')
        {
            Vector3 targetDirection = new Vector3(0, 0, 1);
            movementDirection = targetDirection;
            heldDown += Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) && keyPressed == 'S')
        {
            Vector3 targetDirection = new Vector3(0, 0, -1);
            movementDirection = targetDirection;
            heldDown += Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A) && keyPressed == 'A')
        {
            Vector3 targetDirection = new Vector3(-1, 0, 0);
            movementDirection = targetDirection;
            heldDown += Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) && keyPressed == 'D')
        {
            Vector3 targetDirection = new Vector3(1, 0, 0);
            movementDirection = targetDirection;
            heldDown += Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            BallInMotion = true;
            heldDown = Mathf.Clamp(heldDown, minHeldDown, maxHeldDown);
        }


        if (BallInMotion == true)
        {
            transform.position = transform.position + movementDirection.normalized * Time.deltaTime * (speedForce * heldDown);
            heldDown -= .0025f;
            heldDown = Mathf.Clamp(heldDown, 0.0f, maxHeldDown);
            if (heldDown == 0.0f)
            {
                BallInMotion = false;
            }
        }
           


        if (transform.position.x > constrainDistant)
        {
            transform.position = new Vector3(constrainDistant, transform.position.y, transform.position.z);
            BallInMotion = false;
            movementDirection = Vector3.zero;
        }
        if (transform.position.x < -constrainDistant)
        {
            transform.position = new Vector3(-constrainDistant, transform.position.y, transform.position.z);
            BallInMotion = false;
            movementDirection = Vector3.zero;
        }
        if (transform.position.z > constrainDistant)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, constrainDistant);
            BallInMotion = false;
            movementDirection = Vector3.zero;
        }
        if (transform.position.z < -constrainDistant)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -constrainDistant);
            BallInMotion = false;
            movementDirection = Vector3.zero;
        }
        

        /*
        // MEDIUM CHALLENGE
        if (Input.GetKeyDown(KeyCode.W))
        {
            Vector3 targetDirection = new Vector3(0, 0, 1);
            movementDirection = Vector3.zero;
            movementDirection = movementDirection + targetDirection;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Vector3 targetDirection = new Vector3(0, 0, -1);
            movementDirection = Vector3.zero;
            movementDirection = movementDirection + targetDirection;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Vector3 targetDirection = new Vector3(-1, 0, 0);
            movementDirection = Vector3.zero;
            movementDirection = movementDirection + targetDirection;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Vector3 targetDirection = new Vector3(1, 0, 0);
            movementDirection = Vector3.zero;
            movementDirection = movementDirection + targetDirection;
        }

        transform.position = transform.position + movementDirection.normalized * Time.deltaTime * speedForce;


        if (transform.position.x > constrainDistant)
        {
            transform.position = new Vector3(constrainDistant, transform.position.y, transform.position.z);
            movementDirection = Vector3.zero;
        }
        if (transform.position.x < -constrainDistant)
        {
            transform.position = new Vector3(-constrainDistant, transform.position.y, transform.position.z);
            movementDirection = Vector3.zero;
        }
        if (transform.position.z > constrainDistant)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, constrainDistant);
            movementDirection = Vector3.zero;
        }
        if (transform.position.z < -constrainDistant)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -constrainDistant);
            movementDirection = Vector3.zero;
        }
        
        */

        /*
        // EASY CHALLENGE
        Vector3 movementDirection = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 targetDirection = new Vector3(0, 0, 1);
            //transform.position = transform.position + targetDirection * Time.deltaTime * speedForce;
            movementDirection = movementDirection + targetDirection;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 targetDirection = new Vector3(0, 0, -1);
            //transform.position = transform.position + targetDirection * Time.deltaTime * speedForce;
            movementDirection = movementDirection + targetDirection;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 targetDirection = new Vector3(-1, 0, 0);
            //transform.position = transform.position + targetDirection * Time.deltaTime * speedForce;
            movementDirection = movementDirection + targetDirection;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 targetDirection = new Vector3(1, 0, 0);
            //transform.position = transform.position + targetDirection * Time.deltaTime * speedForce;
            movementDirection = movementDirection + targetDirection;
        }

        transform.position = transform.position + movementDirection.normalized * Time.deltaTime * speedForce;

        //Constrain to <constrainDistant> unit in X and Z from origin

        
        //Cleaner
        //Vector3 clampedPosition = new Vector3(Mathf.Clamp(transform.position.x, -constrainDistant, constrainDistant),
        //    transform.position.y, Mathf.Clamp(transform.position.z, -constrainDistant, constrainDistant));
        //transform.position = clampedPosition;
        

        //Conditional logic
        if (transform.position.x > constrainDistant)
        {
            transform.position = new Vector3(constrainDistant, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -constrainDistant)
        {
            transform.position = new Vector3(-constrainDistant, transform.position.y, transform.position.z);
        }
        if (transform.position.z > constrainDistant)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, constrainDistant);
        }
        if (transform.position.z < -constrainDistant)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -constrainDistant);
        }
        */
    }
}
