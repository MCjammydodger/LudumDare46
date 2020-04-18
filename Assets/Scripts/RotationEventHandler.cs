using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationEventHandler : TimeEventHandler
{
    public Transform target;

    public override void ApplyEvent(TimeEvent timeEvent, bool reverse)
    {
        RotationEvent newEvent = (RotationEvent)timeEvent;
        target.rotation = newEvent.rotation;
    }

    public override void UpdateEventHandler()
    {
        RotationEvent newEvent = new RotationEvent();
        newEvent.rotation = target.rotation;
        TimeController.instance.AddEvent(newEvent, this);
    }
}

public class RotationEvent : TimeEvent
{
    public Quaternion rotation;
}
