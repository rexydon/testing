using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFowardInZ : MonoBehaviour {
    Vector3 z = new Vector3(0, 0, 1);
    public float moveSpeed = 2.0f;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
       
        //Designated position = Current position + direction/ magnitude of movement
        this.transform.position = this.transform.position + z * moveSpeed * Time.deltaTime;

        print(Time.deltaTime);
	}
}
