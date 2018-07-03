using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeMovement : MonoBehaviour {

    public bool up = true;
    public Vector3 movement = new Vector3(0, 1, 0);
    public float lastUpdate = 0.0f;
    private float timer = 0.0f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (timer - lastUpdate >= .5f)
        {
            if (up == true)
            {
                transform.position -= movement;
                if (transform.position.y <= 1)
                {
                    up = false;
                }
            }
            else
            {
                transform.position += movement;
                if (transform.position.y >= 5)
                {
                    up = true;
                }
            }
            lastUpdate = timer;
        }
        timer += Time.deltaTime;
    }
}
