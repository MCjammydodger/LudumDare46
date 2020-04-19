using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public GameObject tutorialPanel;
    public TextMeshProUGUI tutorialText;
    public GameObject gameUI;

    public static TutorialManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void ShowTutorial(string text)
    {
        tutorialText.text = text;
        tutorialPanel.SetActive(true);
        gameUI.SetActive(false);
        TimeController.instance.PauseGameTime();
    }

    private void Update()
    {
        if(tutorialPanel.activeSelf && Input.GetButtonUp("Submit"))
        {
            gameUI.SetActive(true);
            tutorialPanel.SetActive(false);
            TimeController.instance.ResumeGameTime();
        }
    }
}
