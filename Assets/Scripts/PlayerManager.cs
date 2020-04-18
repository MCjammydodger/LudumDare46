using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    private void Awake()
    {
        instance = this;
    }

    public PlayerMovement currentVehicle;

    public PlayerMovement[] vehicles;

    public CameraController cameraController;

    private int currentVehicleIndex = 0;

    private void Start()
    {
        currentVehicle = vehicles[0];
    }

    private void Update()
    {
        if(Input.GetButtonUp("Switch") && TimeController.instance.InRewindMode())
        {
            currentVehicleIndex += 1;
            if(currentVehicleIndex >= vehicles.Length)
            {
                currentVehicleIndex = 0;
            }
            currentVehicle = vehicles[currentVehicleIndex];
            cameraController.target = currentVehicle.transform;
        }
    }

    public void OnPause()
    {
        foreach(PlayerMovement vehicle in vehicles)
        {
            vehicle.OnPause();
        }
    }

    public void OnResume()
    {
        foreach(PlayerMovement vehicle in vehicles)
        {
            vehicle.OnResume();
        }
    }
}
