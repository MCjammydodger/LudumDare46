using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AlienController : MonoBehaviour
{
    public float startTimeLeft = 20;
    public TextMeshProUGUI timeLeftText;

    public float currentTimeLeft = 20;

    public static AlienController instance;

    public TutorialTrigger alienTutorial;

    private Rigidbody rb;

    private void Awake()
    {
        instance = this;
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        currentTimeLeft = startTimeLeft;
    }

    private void Update()
    {
        currentTimeLeft -= Time.deltaTime;
        if (currentTimeLeft <= 0 && !TimeController.instance.IsGameTimePaused())
        {
            timeLeftText.text = "Alien Died!";
            alienTutorial.ActivateTutorial();
            TimeController.instance.EnterRewindMode();
        }
        else if(!TimeController.instance.IsGameTimePaused())
        {
            UpdateTimeLeftText();
        }
    }

    public void UpdateTimeLeftText()
    {
        timeLeftText.text = Mathf.RoundToInt(currentTimeLeft).ToString();
    }

    public void ResetRB()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}
