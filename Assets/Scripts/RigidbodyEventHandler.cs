using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyEventHandler : TimeEventHandler
{
    public Rigidbody target;

    private RigidbodyEvent lastEvent;

    public override void ApplyEvent(TimeEvent timeEvent, bool reverse)
    {
        lastEvent = (RigidbodyEvent)timeEvent;
    }

    public override void UpdateEventHandler()
    {
        if (lastEvent != null)
        {
            target.velocity = lastEvent.velocity;
            target.angularVelocity = lastEvent.angularVelocity;
            target.isKinematic = lastEvent.isKinematic;
            lastEvent = null;
        }
        RigidbodyEvent newEvent = new RigidbodyEvent();
        newEvent.velocity = target.velocity;
        newEvent.angularVelocity = target.angularVelocity;
        newEvent.isKinematic = target.isKinematic;
        TimeController.instance.AddEvent(newEvent, this);
    }
}

public class RigidbodyEvent : TimeEvent
{
    public Vector3 velocity;
    public Vector3 angularVelocity;
    public bool isKinematic;
}