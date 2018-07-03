using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obirtAroundPoint : MonoBehaviour {

    public Transform pointToRotate;
    public float rotationspeed = 90;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 diffrence = transform.position - pointToRotate.position;
        float rotation = rotationspeed * Time.deltaTime;
        Quaternion appliedRotation = Quaternion.AngleAxis(rotation, Vector3.up);
        Vector3 rotatedDiffrence = appliedRotation * diffrence;


        transform.position = pointToRotate.position + rotatedDiffrence;
	}
}
