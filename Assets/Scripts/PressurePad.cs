using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePad : MonoBehaviour
{

    public Bridge bridge;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponent<PlayerMovement>() != null)
        {
            bridge.Activate();
        }
    }
}
