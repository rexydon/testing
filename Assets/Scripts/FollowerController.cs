using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerController : MonoBehaviour
{
    public LayerMask raycastLayers;
    public LayerMask walls;
    public GameObject player;
    RaycastHit hitInfo;
    public float rayDistance = 10.0f;
    public float speedForce = 7.5f;
    private Vector3 movementDirection = Vector3.zero;
    private Vector3 playerLocation;
    public float constrainDistant = 2.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movementDirection = Vector3.zero;
        playerLocation = player.transform.position - transform.position;

        if (Physics.Raycast(transform.position, playerLocation, out hitInfo, rayDistance))
        {
            if(hitInfo.transform.name == "player")
            {
                movementDirection = playerLocation;

                if (System.Math.Abs(playerLocation.x) < constrainDistant && System.Math.Abs(playerLocation.z) < constrainDistant)
                {
                    movementDirection = Vector3.zero;
                }

                transform.position = transform.position + movementDirection.normalized * Time.deltaTime * speedForce;
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + playerLocation.normalized * rayDistance);
    }
}
