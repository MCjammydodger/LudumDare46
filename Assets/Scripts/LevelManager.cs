using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public GameObject openingCinematic;
    public Camera mainCam;
    public TutorialTrigger introTutorial;

    public bool skipOpeningCinematic;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if (skipOpeningCinematic)
        {
            OpeningFinished();
        }
        else
        {
            TimeController.instance.PauseGameTime();
            mainCam.gameObject.SetActive(false);
        }
    }

    public void OpeningFinished()
    {
        openingCinematic.SetActive(false);
        mainCam.gameObject.SetActive(true);
        TimeController.instance.ResumeGameTime();
        introTutorial.ActivateTutorial();
    }
}
