using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Transform truckSpawn;
    public Transform tankSpawn;
    public Transform alienSpawn;

    public float newTimer = 20;

    public void ActivateCheckpoint()
    {
        PlayerManager.instance.OnPause();
        PlayerManager.instance.vehicles[0].transform.position = truckSpawn.position;
        PlayerManager.instance.vehicles[0].transform.rotation = truckSpawn.rotation;
        PlayerManager.instance.vehicles[1].transform.position = tankSpawn.position;
        PlayerManager.instance.vehicles[1].transform.rotation = tankSpawn.rotation;
        AlienController.instance.transform.position = alienSpawn.position;
        AlienController.instance.transform.rotation = alienSpawn.rotation;
        AlienController.instance.ResetRB();
        PlayerManager.instance.SwitchToVehicle(0);
        AlienController.instance.currentTimeLeft = newTimer;
        PlayerManager.instance.OnResume();
        TimeController.instance.RemoveAllTimelines();

    }
}
