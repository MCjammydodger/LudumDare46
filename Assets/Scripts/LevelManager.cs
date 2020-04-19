using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public GameObject openingCinematic;
    public Camera mainCam;
    public TutorialTrigger introTutorial;
    public GameObject gameUI;
    public GameObject endingCinematic;

    public bool skipOpeningCinematic;
    public Checkpoint debugStartCheckpoint;
    public GameObject startMenu;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if (skipOpeningCinematic)
        {
            OpeningFinished();
            if(debugStartCheckpoint != null)
            {
                debugStartCheckpoint.ActivateCheckpoint();
            }
        }
        else
        {
            TimeController.instance.PauseGameTime();
            mainCam.gameObject.SetActive(false);
            gameUI.SetActive(false);
        }
    }

    public void OpeningFinished()
    {
        startMenu.SetActive(false);
        openingCinematic.SetActive(false);
        mainCam.gameObject.SetActive(true);
        gameUI.SetActive(true);
        TimeController.instance.ResumeGameTime();
        introTutorial.ActivateTutorial();
    }

    public void GameFinished()
    {
        TimeController.instance.PauseGameTime();
        mainCam.gameObject.SetActive(false);
        gameUI.SetActive(false);
        endingCinematic.SetActive(true);
    }

    public void ShowMenu()
    {
        startMenu.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
