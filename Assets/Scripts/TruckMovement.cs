using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckMovement : PlayerMovement
{
    public float turnSpeed = 2.0f;

    protected override void ApplyMovement(Vector3 desiredDirection)
    {
        if (desiredSpeed != 0)
        {
            Quaternion desiredRotation = Quaternion.LookRotation(desiredDirection, Vector3.up);
            float angleDifference;
            angleDifference = Quaternion.Angle(transform.rotation, desiredRotation);
            angleDifference = Vector3.Angle(transform.right, desiredDirection) > 90 ? angleDifference * -1 : angleDifference;
            if (Mathf.Abs(angleDifference) < turnSpeed * Time.deltaTime)
            {
                transform.rotation = desiredRotation;
            }
            else
            {
                float direction = angleDifference / Mathf.Abs(angleDifference);
                transform.Rotate(Vector3.up, turnSpeed * direction * Time.deltaTime);
            }
            Debug.DrawRay(transform.position, desiredDirection, Color.blue);
            Debug.DrawRay(transform.position, transform.right, Color.red);

        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(transform.forward * desiredSpeed * speed, ForceMode.VelocityChange);
    }
}
