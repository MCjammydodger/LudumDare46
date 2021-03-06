﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeEventHandler : TimeEventHandler
{
    public Bridge bridge;

    public override void ApplyEvent(TimeEvent timeEvent, bool reverse)
    {
        BridgeEvent newEvent = (BridgeEvent)timeEvent;
        bridge.activated = newEvent.activated;
        bridge.lerpValue = newEvent.lerpValue;
    }

    public override void UpdateEventHandler()
    {
        if(bridge.lerpValue < 1.2f)
        {
            BridgeEvent newEvent = new BridgeEvent();
            newEvent.activated = bridge.IsActivated();
            newEvent.lerpValue = bridge.lerpValue;
            TimeController.instance.AddEvent(newEvent, this);
        }
    }
}

public class BridgeEvent : TimeEvent
{
    public bool activated;
    public float lerpValue;
}
