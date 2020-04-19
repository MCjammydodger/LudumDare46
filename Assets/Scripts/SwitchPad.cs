using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SwitchPad : MonoBehaviour
{
    private List<PlayerMovement> vehiclesOnPad;
    public TextMeshProUGUI keyhint;
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
                if(PlayerManager.instance.currentVehicle == playerMovement)
                {
                    keyhint.text = "";
                }
                vehiclesOnPad.Remove(playerMovement);
            }
        }
    }

    private void Update()
    {
        if (!TimeController.instance.IsGameTimePaused() && vehiclesOnPad.Contains(PlayerManager.instance.currentVehicle))
        {
            keyhint.text = "Press E to switch vehicle.";
            if (Input.GetButtonUp("Switch"))
            {
                keyhint.text = "";
                PlayerManager.instance.SwitchToNextVehicle();
            }
        }
    }
}
