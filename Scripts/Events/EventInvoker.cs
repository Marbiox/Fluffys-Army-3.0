using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventInvoker : MonoBehaviour
{
    //adds dictionary for invokers
    public Dictionary<EventName, UnityEvent> emptyUnityEvents = new Dictionary<EventName, UnityEvent>();
    public Dictionary<EventName, UnityEvent<int>> intUnityEvents = new Dictionary<EventName, UnityEvent<int>>();
    public Dictionary<EventName, UnityEvent<bool>> boolUnityEvents = new Dictionary<EventName, UnityEvent<bool>>();

    UnityEvent<int> levelEvent = new UnityEvent<int>();
    UnityEvent pauseMenuClosedEvent = new UnityEvent();
    UnityEvent gameoverEvent = new UnityEvent();
    UnityEvent<bool> musicPlayingEvent = new UnityEvent<bool>();
    UnityEvent<int> addScoreEvent = new UnityEvent<int>();
    UnityEvent<int> updateHealthBarEvent = new UnityEvent<int>();
    UnityEvent<int> updateTimeLeftEvent = new UnityEvent<int>();
    UnityEvent bossSpawnedEvent = new UnityEvent();
    UnityEvent gemCollectedEvent = new UnityEvent();
    UnityEvent gemComboEndedEvent = new UnityEvent();

    void Awake()
    {
        //adds invokers to dictionary and EventManager
        intUnityEvents.Add(EventName.levelIncrease, levelEvent);
        EventManager.AddInvoker(EventName.levelIncrease, this);
        emptyUnityEvents.Add(EventName.pauseMenuClosed, pauseMenuClosedEvent);
        EventManager.AddInvoker(EventName.pauseMenuClosed, this);
        emptyUnityEvents.Add(EventName.gameOver, gameoverEvent);
        EventManager.AddInvoker(EventName.gameOver, this);
        boolUnityEvents.Add(EventName.musicPlaying, musicPlayingEvent);
        EventManager.AddInvoker(EventName.musicPlaying, this);
        intUnityEvents.Add(EventName.addScore, addScoreEvent);
        EventManager.AddInvoker(EventName.addScore, this);
        intUnityEvents.Add(EventName.updateHealthBar, updateHealthBarEvent);
        EventManager.AddInvoker(EventName.updateHealthBar, this);
        intUnityEvents.Add(EventName.updateTimeLeft, updateTimeLeftEvent);
        EventManager.AddInvoker(EventName.updateTimeLeft, this);
        emptyUnityEvents.Add(EventName.bossSpawned, bossSpawnedEvent);
        EventManager.AddInvoker(EventName.bossSpawned, this);
        emptyUnityEvents.Add(EventName.gemCollected, gemCollectedEvent);
        EventManager.AddInvoker(EventName.gemCollected, this);
        emptyUnityEvents.Add(EventName.gemComboEnded, gemComboEndedEvent);
        EventManager.AddInvoker(EventName.gemComboEnded, this);
    }
   
    //listener overloads to add listener to event
    public void AddListener(EventName eventName, UnityAction listener)
    {
            if (emptyUnityEvents.ContainsKey(eventName))
            {
                emptyUnityEvents[eventName].AddListener(listener);
            }
    }
 
    public void AddListener(EventName eventName, UnityAction<int> listener)
    {
        if (intUnityEvents.ContainsKey(eventName))
        {
            intUnityEvents[eventName].AddListener(listener);
        }
    }

    public void AddListener(EventName eventName, UnityAction<bool> listener)
    {
        if (boolUnityEvents.ContainsKey(eventName))
        {
            boolUnityEvents[eventName].AddListener(listener);
        }

    }
    //remove invoker
    public void RemoveInvoker(EventName eventName)
    {
        EventManager.RemoveInvoker(eventName, this);
    }
}
