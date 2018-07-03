using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdPersonCamera : MonoBehaviour
{
    public Transform player;
    public float rotateSpeed = 180;
    public float speed = 10;
    private float startRotX;
    public float maxRot = 15;
    public float minRot = 0;

    // Use this for initialization
    void Start()
    {

       
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        Vector3 moveDirection = Vector3.zero;
        Vector3 diffrence = transform.position - player.position;

        if (mouseX != 0)
        {

            float rotation = mouseX * Time.deltaTime * rotateSpeed;
            Quaternion appliedRotation = Quaternion.AngleAxis(rotation, Vector3.up);
            Vector3 rotatedDiffrence = appliedRotation * diffrence;

            transform.position = player.position + rotatedDiffrence;
            // transform.LookAt(player);
            Vector3 targetPoint = new Vector3(transform.position.x, transform.position.y, transform.position.z) - player.transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(-targetPoint, Vector3.up);
            transform.rotation = targetRotation;
            diffrence = transform.position - player.position;
        }

        if (mouseY != 0)
        {
            float rotation = mouseY * Time.deltaTime * rotateSpeed;
            Quaternion appliedRotation = Quaternion.AngleAxis(rotation, Vector3.right);
            Vector3 rotatedDiffrence = appliedRotation * diffrence;

            transform.position = player.position + rotatedDiffrence;
            //Vector3 attempted = player.position + rotatedDiffrence;
            //Vector3 newPost = new Vector3(attempted.x, Mathf.Clamp(transform.position.y, minRot, maxRot), attempted.z);
            // transform.LookAt(player);
            Vector3 targetPoint = new Vector3(transform.position.x, transform.position.y, transform.position.z) - player.transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(-targetPoint, Vector3.up);
            transform.rotation = targetRotation;
            diffrence = transform.position - player.position;

        }


        if (Input.GetKey(KeyCode.W))
        {
            //  moveDirection += new Vector3(0, 0, 1);
            Vector3 forwardDirection = transform.forward;
            forwardDirection.y = 0;
            forwardDirection.Normalize();
            moveDirection += forwardDirection;
        }
        if (Input.GetKey(KeyCode.S))
        {
            //  moveDirection += new Vector3(0, 0, -1);
            Vector3 forwardDirection = -transform.forward;
            forwardDirection.y = 0;
            forwardDirection.Normalize();
            moveDirection += forwardDirection;

        }
        if (Input.GetKey(KeyCode.A))
        {
            // moveDirection += new Vector3(-1, 0, 0);
            Vector3 rightDirection = -transform.right;
            rightDirection.y = 0;
            rightDirection.Normalize();
            moveDirection += rightDirection;
        }
        if (Input.GetKey(KeyCode.D))
        {
            // moveDirection += new Vector3(1, 0, 0);
            Vector3 rightDirection = transform.right;
            rightDirection.y = 0;
            rightDirection.Normalize();
            moveDirection += rightDirection;
        }

        if (moveDirection.x != 0 && moveDirection.z != 0)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            player.transform.rotation = targetRotation;
            player.transform.position += moveDirection.normalized * speed * Time.deltaTime;
            transform.position = player.position + diffrence;
        }
    }
}
