using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformEventHandler : TimeEventHandler
{
    public Transform target;

    public override void ApplyEvent(TimeEvent timeEvent, bool reverse)
    {
        TransformEvent newEvent = (TransformEvent)timeEvent;
        target.position = newEvent.position;
        target.rotation = newEvent.rotation;
    }

    public override void UpdateEventHandler()
    {
        TransformEvent newEvent = new TransformEvent();
        newEvent.position = target.position;
        newEvent.rotation = target.rotation;
        TimeController.instance.AddEvent(newEvent, this);
    }
}

[System.Serializable]
public class TransformEvent : TimeEvent
{
    public Vector3 position;
    public Quaternion rotation;
}