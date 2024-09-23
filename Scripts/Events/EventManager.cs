using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    //dictionary for event type of a certain event
    static Dictionary<EventName, EventType> EventTypes = new Dictionary<EventName, EventType>();
    //event support
    static Dictionary<EventName,List<EventInvoker>> invokers = new Dictionary<EventName,List<EventInvoker>>();
    static Dictionary<EventName, List<UnityAction>> emptyListeners = new Dictionary<EventName, List<UnityAction>>();
    static Dictionary<EventName, List<UnityAction<int>>> intListeners = new Dictionary<EventName, List<UnityAction<int>>>();
    static Dictionary<EventName, List<UnityAction<bool>>> boolListeners = new Dictionary<EventName, List<UnityAction<bool>>>();

    static bool initialized = false;

    public static void Initialize()
    {
        if (!initialized)
        {
            initialized = true;

            //Adds EventType to EventName
            EventTypes.Add(EventName.levelIncrease, EventType.Int);
            EventTypes.Add(EventName.pauseMenuClosed, EventType.Empty);
            EventTypes.Add(EventName.gameOver, EventType.Empty);
            EventTypes.Add(EventName.musicPlaying, EventType.Bool);
            EventTypes.Add(EventName.addScore, EventType.Int);
            EventTypes.Add(EventName.updateHealthBar, EventType.Int);
            EventTypes.Add(EventName.updateTimeLeft, EventType.Int);
            EventTypes.Add(EventName.bossSpawned, EventType.Empty);
            EventTypes.Add(EventName.gemCollected, EventType.Empty);
            EventTypes.Add(EventName.gemComboEnded, EventType.Empty);

            foreach (EventName name in Enum.GetValues(typeof(EventName)))
            {
                //checks event type
                if (EventTypes[name] == EventType.Empty)
                {
                    //adds invoker and listener if invoker list does not contain it for the event
                    if (!invokers.ContainsKey(name))
                    {
                        invokers.Add(name, new List<EventInvoker>());
                        emptyListeners.Add(name, new List<UnityAction>());
                    }
                    else
                    {
                        invokers[name].Clear();
                        emptyListeners[name].Clear();
                    }
                }
                //checks event type
                else if (EventTypes[name] == EventType.Int)
                {
                    //same thing as above but for bools
                    if (!invokers.ContainsKey(name))
                    {
                        invokers.Add(name, new List<EventInvoker>());
                        intListeners.Add(name, new List<UnityAction<int>>());
                    }
                    else
                    {
                        invokers[name].Clear();
                        intListeners[name].Clear();
                    }
                }
                else if (EventTypes[name] == EventType.Bool)
                {
                    //same thing as above but for bools
                    if (!invokers.ContainsKey(name))
                    {
                        invokers.Add(name, new List<EventInvoker>());
                        boolListeners.Add(name, new List<UnityAction<bool>>());
                    }
                    else
                    {
                        invokers[name].Clear();
                        boolListeners[name].Clear();
                    }
                }
            }
        }
    }
    public static void AddInvoker(EventName eventName, EventInvoker invoker)
    {
        //check type of event name and adds accordingly
        if (EventTypes[eventName] == EventType.Empty)
        {
            foreach (UnityAction listener in emptyListeners[eventName])
            {
                //adds listeners to events
                invoker.AddListener(eventName, listener);
            }
        }
        else if (EventTypes[eventName] == EventType.Int)
        {
            foreach (UnityAction<int> listener in intListeners[eventName])
            {
                //adds listeners to events
                invoker.AddListener(eventName, listener);
            }
        }
        else if (EventTypes[eventName] == EventType.Bool)
        {
            foreach (UnityAction<bool> listener in boolListeners[eventName])
            {
                //adds listeners to events
                invoker.AddListener(eventName, listener);
            }
        }
        //adds invoker to dictionary
        invokers[eventName].Add(invoker);
    }
    //overloading constructers for every type of event
    public static void AddListener(EventName eventName, UnityAction listener)
    {
        foreach (EventInvoker invoker in invokers[eventName])
        {
            invoker.AddListener(eventName,listener);
        }
        emptyListeners[eventName].Add(listener);
    }
    public static void AddListener(EventName eventName, UnityAction<int> listener)
    {
        foreach (EventInvoker invoker in invokers[eventName])
        {
            invoker.AddListener(eventName, listener);
        }
        intListeners[eventName].Add(listener);
    }
    public static void AddListener(EventName eventName, UnityAction<bool> listener)
    {
        foreach (EventInvoker invoker in invokers[eventName])
        {
            invoker.AddListener(eventName, listener);
        }
        boolListeners[eventName].Add(listener);
    }
    //removes invoker from invoker dictionary for optimization
    public static void RemoveInvoker(EventName eventName, EventInvoker invoker)
    {
        invokers[eventName].Remove(invoker);
    }
}
