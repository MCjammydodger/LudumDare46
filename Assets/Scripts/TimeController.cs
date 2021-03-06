﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeController : MonoBehaviour
{
    [System.Serializable]
    public class TimeEventGameObject
    {
        public List<TimeEvent> timeEvents;
        public GameObject gameObject;

        public TimeEventGameObject(GameObject gameObject)
        {
            timeEvents = new List<TimeEvent>();
            this.gameObject = gameObject;
        }

        public int currentEventIndex = 0;
        public bool nonPlayerObject = false;
    }

    public int rewindStepsPerFrame = 4;
    public TextMeshProUGUI rewindText;

    private List<TimeEventGameObject> timeEventGameObjects;
    private List<TimeEventHandler> timeEventHandlers;

    public int currentFrame = 0;
    private int rewindModeFrame = 0;


    private bool inRewindMode = false;
    public static TimeController instance;
    public TextMeshProUGUI keyhint;
    public TextMeshProUGUI keyhint2;

    private void Awake()
    {
        instance = this;
        timeEventGameObjects = new List<TimeEventGameObject>();
        timeEventHandlers = new List<TimeEventHandler>();
    }

    public TimeEventGameObject GetTimeEventGameObject(GameObject gameObject)
    {
        TimeEventGameObject timeEventGameObject = null;

        foreach (TimeEventGameObject go in timeEventGameObjects)
        {
            if (go.gameObject == gameObject)
            {
                timeEventGameObject = go;
                break;
            }
        }
        if (timeEventGameObject == null)
        {
            timeEventGameObject = new TimeEventGameObject(gameObject);
            timeEventGameObjects.Add(timeEventGameObject);
        }
        return timeEventGameObject;
    }

    public void AddEvent(TimeEvent eventToAdd, TimeEventHandler eventHandler)
    {
        eventToAdd.frame = currentFrame;
        eventToAdd.handler = eventHandler;
        TimeEventGameObject go = GetTimeEventGameObject(eventHandler.gameObject);
        go.timeEvents.Add(eventToAdd);
        go.nonPlayerObject = eventHandler.nonPlayerHandler;
    }

    public void AddEventHandler(TimeEventHandler eventHandler)
    {
        timeEventHandlers.Add(eventHandler);
    }

    private void PlayEventsAtCurrentRewindFrame()
    {
        foreach (TimeEventGameObject go in timeEventGameObjects)
        {
            while (go.currentEventIndex >= 0 && go.timeEvents[go.currentEventIndex].frame >= rewindModeFrame)
            {
                if (go.timeEvents[go.currentEventIndex].frame == rewindModeFrame)
                {
                    go.timeEvents[go.currentEventIndex].ApplyEvent(true);
                }
                go.currentEventIndex -= 1;
            }
        }
    }

    private void PlayEventsAtCurrentForwardFrame()
    {
        foreach (TimeEventGameObject go in timeEventGameObjects)
        {
            while (go.currentEventIndex < go.timeEvents.Count && go.timeEvents[go.currentEventIndex].frame <= currentFrame)
            {
                if (go.timeEvents[go.currentEventIndex].frame == currentFrame)
                {
                    go.timeEvents[go.currentEventIndex].ApplyEvent(false);
                }
                go.currentEventIndex += 1;
            }
        }
    }

    public void RemoveFutureEvents(TimeEventGameObject go)
    {  
        for(int i = go.timeEvents.Count - 1; i >= 0; i--)
        {
            if(go.timeEvents[i].frame > currentFrame)
            {
                go.timeEvents.RemoveAt(i);
            }
        }
    }

    public void EnterRewindMode()
    {
        rewindText.text = "<<";
        if (!inRewindMode)
        {
            keyhint.text = "Press SPACE to resume time.";
            keyhint2.text = "Hold Q to rewind.";
            PauseGameTime();
            inRewindMode = true;
            rewindModeFrame = currentFrame;
            foreach (TimeEventGameObject go in timeEventGameObjects)
            {
                go.currentEventIndex = go.timeEvents.Count - 1;
            }
            PlayerManager.instance.OnPause();
            //PlayEventsAtCurrentRewindFrame();
        }
        else
        {
            for (int i = 0; i < rewindStepsPerFrame; i++)
            {
                rewindModeFrame = rewindModeFrame - 1;
                if (rewindModeFrame < 0)
                {
                    rewindModeFrame = 0;
                    break;
                }
                PlayEventsAtCurrentRewindFrame();
            }
        }
    }

    public void Update()
    {
        if(inRewindMode)
        {
            rewindText.text = "II";
        }

        if(Input.GetButton("Rewind"))
        {
            EnterRewindMode();
        }

        if(inRewindMode && Input.GetButtonUp("Submit"))
        {
            keyhint.text = "";
            keyhint2.text = "";
            ResumeGameTime();
            inRewindMode = false;
            currentFrame = rewindModeFrame;
            foreach(TimeEventGameObject go in timeEventGameObjects)
            {
                go.currentEventIndex = 0;
                if(go.gameObject == PlayerManager.instance.currentVehicle.gameObject || go.nonPlayerObject)
                {
                    RemoveFutureEvents(go);
                }
            }
            PlayerManager.instance.OnResume();
        }
        else if(inRewindMode && Input.GetButtonUp("Reset"))
        {
            //for (int i = rewindModeFrame; i >= 0; i--)
            //{
            //    rewindModeFrame = rewindModeFrame - 1;
            //    if (rewindModeFrame < 0)
            //    {
            //        rewindModeFrame = 0;
            //        break;
            //    }
            //    PlayEventsAtCurrentRewindFrame();
            //}
            //RemoveAllTimelines();
            //keyhint.text = "";
            //keyhint2.text = "";
            //ResumeGameTime();
            //inRewindMode = false;
            //PlayerManager.instance.SwitchToVehicle(0);
            //PlayerManager.instance.OnResume();

        }

        if (!IsGameTimePaused())
        {
            rewindText.text = "";
            PlayEventsAtCurrentForwardFrame();
            foreach (TimeEventHandler handler in timeEventHandlers)
            {
                if (handler.gameObject == PlayerManager.instance.currentVehicle.gameObject || handler.nonPlayerHandler)
                {
                    // Only add new events to the currently controlled vehicle.
                    handler.UpdateEventHandler();
                }
            }

            currentFrame += 1;
        }
    }

    public void RemoveAllTimelines()
    {
        timeEventGameObjects.Clear();
    }

    public void PauseGameTime()
    {
        Time.timeScale = 0.0f;
    }

    public void ResumeGameTime()
    {
        Time.timeScale = 1.0f;
    }

    public bool IsGameTimePaused()
    {
        return Time.timeScale == 0;
    }

    public bool InRewindMode()
    {
        return inRewindMode;
    }
}
