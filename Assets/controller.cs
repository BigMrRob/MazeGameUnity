using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    public GameObject ground;
    private bool walking = false;

    public float moveSpeed;
    public float zoomSpeed;

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    public float minZoomDist;
    public float maxZoomDist;

    private Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        Move();
        transformCamera();
        
        
    }
    void Move()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        Vector3 dir = transform.forward * zInput + transform.right * xInput;

        transform.position += dir * moveSpeed * Time.deltaTime;
    }

    void transformCamera()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV* Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
}
