using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventInvokerUtils
{

    //allows other classes to invoke events
    //makes EventInvoker static

    public static void Invoke(EventName name)
    {
        EventInvoker().emptyUnityEvents[name].Invoke();
    }
    public static void Invoke(EventName name, int variable)
    {
        EventInvoker().intUnityEvents[name].Invoke(variable);
    }
    public static void Invoke(EventName name, bool variable)
    {
        EventInvoker().boolUnityEvents[name].Invoke(variable);
    }
    public static void RemoveInvoker(EventName name)
    {
        EventInvoker().RemoveInvoker(name);
    }
    static EventInvoker EventInvoker()
    {
        return Camera.main.GetComponent<EventInvoker>();
    }
}
