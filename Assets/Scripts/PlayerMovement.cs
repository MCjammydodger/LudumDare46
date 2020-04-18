using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerMovement : MonoBehaviour
{
    public float speed = 10.0f;

    protected Rigidbody rb;

    protected Vector3 desiredDirection;
    protected float desiredSpeed;

    private Camera cam;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
    }

    private void Update()
    {
        if (PlayerManager.instance.currentVehicle == this)
        {
            desiredDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
            desiredSpeed = Mathf.Abs(desiredDirection.magnitude);
            desiredDirection = cam.transform.TransformDirection(desiredDirection);
            desiredDirection.y = 0;
            desiredDirection.Normalize();
            ApplyMovement(desiredDirection);
        }
    }

    protected abstract void ApplyMovement(Vector3 desiredDirection);

    public void OnPause()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.isKinematic = true;
    }

    public void OnResume()
    {
        if(PlayerManager.instance.currentVehicle == this)
        {
            rb.isKinematic = false;
        }
    }
}
