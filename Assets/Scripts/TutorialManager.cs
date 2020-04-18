using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public GameObject tutorialPanel;
    public TextMeshProUGUI tutorialText;

    public static TutorialManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void ShowTutorial(string text)
    {
        tutorialText.text = text;
        tutorialPanel.SetActive(true);
        TimeController.instance.PauseGameTime();
    }

    private void Update()
    {
        if(tutorialPanel.activeSelf && Input.GetButtonUp("Submit"))
        {
            tutorialPanel.SetActive(false);
            TimeController.instance.ResumeGameTime();
        }
    }
}
