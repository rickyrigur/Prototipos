using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    // Private variables
    private float turnSpeed = 35.0f;
    private float speed = 10.0f;
    private float horizontalInput;
    private float forwardInput;
    public Camera Player2cam1;
    public Camera Player2cam2;
    //private Vector3 offset = new Vector3(0, 2.14f, 0.58f);

    void Start()
    {
        //cam1.gameObject.SetActive(true);
        //cam2.gameObject.SetActive(false);
    }

    void Update()
    {
        // Get Input for forward and side movement
        horizontalInput = Input.GetAxis("Horizontal2");
        forwardInput = Input.GetAxis("Vertical2");

        // Move the vehicle forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        // Rotate left or right the vehicle
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
        //transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);
        //cam2.transform.position = transform.position + offset;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Player2cam1.enabled)
            {
                //cam1.gameObject.SetActive(false);
                //cam2.gameObject.SetActive(true);
                Player2cam1.enabled = false;
                Player2cam2.enabled = true;
            }
            else if (Player2cam2.enabled)
            {
                //cam1.gameObject.SetActive(true);
                //cam2.gameObject.SetActive(false);
                Player2cam1.enabled = true;
                Player2cam2.enabled = false;
            }
            //
            //
        }
    }
}

