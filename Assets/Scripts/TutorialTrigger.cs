using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    public string tutorialText;
    public PlayerMovement requiredVehicle;

    private bool activated = false;

    private void OnTriggerEnter(Collider other)
    {
        PlayerMovement pm = other.transform.GetComponent<PlayerMovement>();
        if(pm != null)
        {
            if(requiredVehicle == null || pm == requiredVehicle)
            {
                ActivateTutorial();
            }
        }
    }

    public void ActivateTutorial()
    {
        if (activated == false)
        {
            activated = true;
            TutorialManager.instance.ShowTutorial(tutorialText);
        }
    }

}
