using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinimaticCore : MonoBehaviour {

    private CharacterController characterController;
    private float speedReduction;
    public float moveSpeed = 5;
    public float radiusOfSatisfaction = 1;
    public float radiusOfApproch = 2;
    public bool byWaypoints = false;
    public WayPointMove waypointController;
   

    private Vector3 target = Vector3.zero;
    private Vector3 moveDirection = Vector3.zero;

    public bool isSeekTargetSet;
    private bool isFleePositionSet = false;


    // Use this for initialization
    void Start()
    {
        characterController = GetComponent<CharacterController>();
       
    }

    // Update is called once per frame
    void Update()
    {
       
        if (isSeekTargetSet)
        {
            moveDirection = target - transform.position;
            if (Vector3.Distance(target, transform.position) < radiusOfApproch)
            {
                speedReduction = ((Vector3.Distance(target, transform.position) - radiusOfSatisfaction) / (radiusOfApproch - radiusOfSatisfaction)+ .1f);
                characterController.Move(moveDirection.normalized * (moveSpeed * speedReduction) * Time.deltaTime);
            }
            else
            {
                characterController.Move(moveDirection.normalized * moveSpeed * Time.deltaTime);
            }
            
            if (Vector3.Distance(target, transform.position) < radiusOfSatisfaction)
            {
                isSeekTargetSet = false;
            }
        }
        if (isFleePositionSet)
        {
            moveDirection = transform.position - target;
            characterController.Move(moveDirection.normalized * moveSpeed * Time.deltaTime);
        }
        if (moveDirection != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(moveDirection);
    }

    public void Seek(Vector3 position)
    {
        target = position;
        target.y = transform.position.y;
        isSeekTargetSet = true;
        isFleePositionSet = false;
    }

    public void Flee(Vector3 position)
    {
        target = position;
        target.y = transform.position.y;
        isSeekTargetSet = false;
        isFleePositionSet = true;
    }
}
