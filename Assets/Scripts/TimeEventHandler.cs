using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TimeEventHandler : MonoBehaviour
{
    private void Start()
    {
        TimeController.instance.AddEventHandler(this);    
    }

    public abstract void UpdateEventHandler();

    public abstract void ApplyEvent(TimeEvent timeEvent);
}

[System.Serializable]
public class TimeEvent
{
    public int frame;
    public TimeEventHandler handler;

    public void ApplyEvent()
    {
        handler.ApplyEvent(this);
    }
}