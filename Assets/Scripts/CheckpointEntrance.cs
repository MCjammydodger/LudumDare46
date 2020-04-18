using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointEntrance : MonoBehaviour
{
    public Checkpoint checkpoint;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.GetComponent<AlienController>() != null)
        {
            checkpoint.ActivateCheckpoint();
        }
    }
}
