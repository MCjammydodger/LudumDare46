using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformEventHandler : TimeEventHandler
{
    public override void ApplyEvent(TimeEvent timeEvent)
    {
        TransformEvent newEvent = (TransformEvent)timeEvent;
        transform.position = newEvent.position;
        transform.rotation = newEvent.rotation;
    }

    public override void UpdateEventHandler()
    {
        TransformEvent newEvent = new TransformEvent();
        newEvent.position = transform.position;
        newEvent.rotation = transform.rotation;
        TimeController.instance.AddEvent(newEvent, this);
    }
}

[System.Serializable]
public class TransformEvent : TimeEvent
{
    public Vector3 position;
    public Quaternion rotation;
}