using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPad : MonoBehaviour
{
    private List<PlayerMovement> vehiclesOnPad;

    private void Start()
    {
        vehiclesOnPad = new List<PlayerMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerMovement playerMovement = other.transform.GetComponent<PlayerMovement>();
        if(playerMovement != null)
        {
            if(!vehiclesOnPad.Contains(playerMovement))
            {
                vehiclesOnPad.Add(playerMovement);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerMovement playerMovement = other.transform.GetComponent<PlayerMovement>();
        if(playerMovement != null)
        {
            if(vehiclesOnPad.Contains(playerMovement))
            {
                vehiclesOnPad.Remove(playerMovement);
            }
        }
    }

    private void Update()
    {
        if(Input.GetButtonUp("Switch") && !TimeController.instance.IsGameTimePaused() && vehiclesOnPad.Contains(PlayerManager.instance.currentVehicle))
        {
            PlayerManager.instance.SwitchToNextVehicle();
        }
    }
}
