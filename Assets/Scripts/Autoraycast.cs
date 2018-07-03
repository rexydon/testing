using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autoraycast : MonoBehaviour {

    public LayerMask raycastLayers;
    public LayerMask floorLayer;
    public float rayDistance = 3.0f;
    private Vector3 rayCollisionNormal;
    private bool hitThisFrame = false;
    private Vector3 hitLocationThisFrame = Vector3.zero;
	
    
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        RaycastHit hitInfo;
        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, rayDistance, raycastLayers.value))
        {
            print("Raycast Hit." + hitInfo.transform.name + " at " + hitInfo.point);
            rayCollisionNormal = hitInfo.normal;
            hitLocationThisFrame = hitInfo.point;
            hitThisFrame = true;
        }



        if (Input.GetMouseButtonDown(0))
        {
            Ray intoScreen = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(intoScreen, out hitInfo, 1000, floorLayer))
            {
                transform.position = hitInfo.point + new Vector3(0, 1, 0);
            }
        }
	}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * rayDistance);

        if (hitThisFrame)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(hitLocationThisFrame, hitLocationThisFrame + rayCollisionNormal);
        }
    }

}
