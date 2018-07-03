using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonControls : MonoBehaviour
{
    public float speed = 4.0f;
    public float rotationSpeed = 180f;
    public GameObject playerCamera;
    public float rotX;
    public float minRot;
    public float maxRot;

    // Use this for initialization
    void Start()
    {
        rotX = playerCamera.transform.eulerAngles.x;
        minRot = -90.0f;
        maxRot = 90;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            //  moveDirection += new Vector3(0, 0, 1);

            moveDirection += transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            //  moveDirection += new Vector3(0, 0, -1);

            moveDirection += -transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            // moveDirection += new Vector3(-1, 0, 0);

            moveDirection += -transform.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            // moveDirection += new Vector3(1, 0, 0);

            moveDirection += transform.right;
        }

        transform.position += moveDirection.normalized * speed * Time.deltaTime;

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");



        if (mouseX != 0)
        {
            transform.Rotate(transform.up, rotationSpeed * mouseX * Time.deltaTime, Space.World);
        }
        

        if (mouseY != 0)
        {

            rotX += mouseY * rotationSpeed * Time.deltaTime;

            rotX = Mathf.Clamp(rotX, minRot, maxRot);

            Vector3 localRotation = new Vector3(rotX, 0.0f, 0.0f);

            playerCamera.transform.localEulerAngles = localRotation;

        }
    }
}
