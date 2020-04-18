using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienEventHandler : TimeEventHandler
{
    public AlienController alienController;

    public override void ApplyEvent(TimeEvent timeEvent, bool reverse)
    {
        AlienEvent newEvent = (AlienEvent)timeEvent;
        alienController.currentTimeLeft = newEvent.timeLeft;
        alienController.UpdateTimeLeftText();
    }

    public override void UpdateEventHandler()
    {
        AlienEvent newEvent = new AlienEvent();
        newEvent.timeLeft = alienController.currentTimeLeft;
        TimeController.instance.AddEvent(newEvent, this);
    }
}

public class AlienEvent : TimeEvent
{
    public float timeLeft;
}