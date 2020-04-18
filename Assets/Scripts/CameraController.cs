using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    public Vector3 offsetFromTarget;

    private void Update()
    {
        transform.position = target.position + offsetFromTarget;
        transform.LookAt(target);
    }
}
