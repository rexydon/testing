using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpFromEdge : MonoBehaviour {
    public float xMin;
    public float xMax;
    public float zMin;
    public float zMax;
    System.Random r = new System.Random();

    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < xMin || transform.position.x > xMax || transform.position.z < zMin || transform.position.z > zMax)
        {
            transform.position = new Vector3(r.Next((int)xMin, (int)xMax), transform.position.y, r.Next((int)zMin, (int)zMax));
        }
	}
}
