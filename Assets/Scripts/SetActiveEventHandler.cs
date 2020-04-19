using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveEventHandler : TimeEventHandler
{
    public GameObject target;

    private bool lastActive;

    protected override void Start()
    {
        base.Start();
        lastActive = target.activeSelf;
    }

    public override void ApplyEvent(TimeEvent timeEvent, bool reverse)
    {
        SetActiveEvent newEvent = (SetActiveEvent)timeEvent;
        if(reverse)
        {
            target.SetActive(!newEvent.activate);
        }
        else
        {
            target.SetActive(newEvent.activate);
        }
        lastActive = target.activeSelf;
    }

    public override void UpdateEventHandler()
    {
        if(target.activeSelf != lastActive)
        {
            lastActive = target.activeSelf;
            SetActiveEvent newEvent = new SetActiveEvent();
            newEvent.activate = target.activeSelf;
            TimeController.instance.AddEvent(newEvent, this);
        }
    }
}

public class SetActiveEvent : TimeEvent
{
    public bool activate;
}