using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : PlayerMovement
{
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
        }
    }

    private void FixedUpdate()
    {
        if (desiredDirection == transform.forward)
        {
            rb.AddForce(transform.forward * desiredSpeed * speed, ForceMode.VelocityChange);
        }
    }
}
