using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AlienController : MonoBehaviour
{
    public float startTimeLeft = 20;
    public TextMeshProUGUI timeLeftText;

    public float currentTimeLeft = 20;

    private void Start()
    {
        currentTimeLeft = startTimeLeft;
    }

    private void Update()
    {
        currentTimeLeft -= Time.deltaTime;
        if(currentTimeLeft <= 0)
        {
            TimeController.instance.EnterRewindMode();
        }
        UpdateTimeLeftText();
    }

    public void UpdateTimeLeftText()
    {
        timeLeftText.text = currentTimeLeft.ToString();
    }
}
