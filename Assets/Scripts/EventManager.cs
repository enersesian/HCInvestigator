using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour {


    private Dictionary<string, UnityEvent> eventDict;

    private static EventManager eventManager;

    private static EventManager instance
    {
        get
        {
            if(!eventManager)
            {
                eventManager = FindObjectOfType(typeof(EventManager)) as EventManager;
                if(!eventManager)
                {
                    Debug.LogError("Need to have active Event Manger");
                }
                else
                {
                    eventManager.Init();
                 
                }
            }
            return eventManager;

        }
    }

    void Init()
    {
        if(eventDict == null)
        {
            eventDict = new Dictionary<string, UnityEvent>();
        }
    }

    public static void StartListening(string eventName, UnityAction listner)
    {
        UnityEvent thisevent = null;
        if(instance.eventDict.TryGetValue(eventName, out thisevent))
        {
            thisevent.AddListener(listner);
        }
        else
        {
            thisevent = new UnityEvent();
            thisevent.AddListener(listner);
            instance.eventDict.Add(eventName, thisevent);
        }
    }
    
    public static void StopListening(string eventName, UnityAction listner)
    {
        if(eventManager == null)
        {
            return;
        }
        UnityEvent thisevent = null;
        if(instance.eventDict.TryGetValue(eventName, out thisevent))
        {
            thisevent.RemoveListener(listner);
        }
    }
    
    public static void TriggerEvent(string eventName)
    {
        UnityEvent thisEvent = null;
        if (instance.eventDict.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke();
        }
    }
}
