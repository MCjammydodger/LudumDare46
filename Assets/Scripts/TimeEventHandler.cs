using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TimeEventHandler : MonoBehaviour
{
    public bool nonPlayerHandler = false;

    protected virtual void Start()
    {
        TimeController.instance.AddEventHandler(this);    
    }

    public abstract void UpdateEventHandler();

    public abstract void ApplyEvent(TimeEvent timeEvent, bool reverse);
}

[System.Serializable]
public class TimeEvent
{
    public int frame;
    public TimeEventHandler handler;

    public void ApplyEvent(bool reverse)
    {
        handler.ApplyEvent(this, reverse);
    }
}