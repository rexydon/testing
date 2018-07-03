using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Vector3 movementDirection = Vector3.zero;
    public float speedForce = 4.0f;
    public float rayDistance = 5.0f;
    public LayerMask floor;
    RaycastHit hitInfo;
    private Vector3 distanceToPoint;
    private Vector3 pointToGoTo = Vector3.zero;
    private bool inMovement = false;
    private List<Vector3> waypoints = new List<Vector3>();

    public LayerMask raycastLayers;
    private Vector3 rayCollisionNormal;
    private bool hitThisFrame = false;
    private Vector3 hitLocationThisFrame = Vector3.zero;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        distanceToPoint = pointToGoTo - transform.position;

        if (System.Math.Abs(distanceToPoint.x) < .5 && System.Math.Abs(distanceToPoint.z) < .5)
        {
            inMovement = false;
        }

        if (inMovement == false)
        {
            if (waypoints.Count == 0)
            {
                movementDirection = Vector3.zero;
            }
            else
            {
                pointToGoTo = waypoints[0];
                waypoints.RemoveAt(0);
                movementDirection = pointToGoTo - transform.position + new Vector3(0, 1, 0);
                inMovement = true;
            }
        }
        if (inMovement == true)
        {
            movementDirection = pointToGoTo - transform.position + new Vector3(0, 1, 0);
        }

        if (Input.GetKey(KeyCode.W))
        {
            Vector3 targetDirection = new Vector3(0, 0, 1);
            //transform.position = transform.position + targetDirection * Time.deltaTime * speedForce;
            movementDirection = movementDirection + targetDirection;
            inMovement = false;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 targetDirection = new Vector3(0, 0, -1);
            //transform.position = transform.position + targetDirection * Time.deltaTime * speedForce;
            movementDirection = movementDirection + targetDirection;
            inMovement = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 targetDirection = new Vector3(-1, 0, 0);
            //transform.position = transform.position + targetDirection * Time.deltaTime * speedForce;
            movementDirection = movementDirection + targetDirection;
            inMovement = false;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 targetDirection = new Vector3(1, 0, 0);
            //transform.position = transform.position + targetDirection * Time.deltaTime * speedForce;
            movementDirection = movementDirection + targetDirection;
            inMovement = false;
        }
        if (Input.GetMouseButtonDown(0))
        {
            print(waypoints.Count);
            Ray intoScreen = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(intoScreen, out hitInfo, 1000, floor))
            {
                waypoints.Add(hitInfo.point);
            }
        }

       

        if (Physics.Raycast(transform.position, pointToGoTo - transform.position, out hitInfo, rayDistance, raycastLayers.value))
        {
            
            rayCollisionNormal = hitInfo.normal;
            hitLocationThisFrame = hitInfo.point;
            hitThisFrame = true;
            movementDirection = (hitLocationThisFrame + rayCollisionNormal) - transform.position;
        }

        transform.position = transform.position + movementDirection.normalized * Time.deltaTime * speedForce;



    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + (pointToGoTo - transform.position).normalized * rayDistance);
        if (hitThisFrame)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(hitLocationThisFrame, hitLocationThisFrame + rayCollisionNormal);
        }
    }
}