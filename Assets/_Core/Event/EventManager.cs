using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour {

    public static EventManager instance;
    private Dictionary<string, UnityEvent> eventDictionary;

    void OnEnable()
    {
        if(instance == null)
        {
            Init();
            instance = this;
        }
        else if(instance!=this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void Init()
    {
        if (eventDictionary == null)
        {
            eventDictionary = new Dictionary<string, UnityEvent>();
        }
    }


    public static void StartListening(string eventName, UnityAction listener)
    {
        if (eventName==null||eventName=="")
        {
            Debug.Log("Empty event name");
            return;
        }

        if(listener==null)
        {
            Debug.Log("Null action");
            return;
        }

        UnityEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            instance.eventDictionary.Add(eventName, thisEvent);
        }
    }

    public static void StopListening(string eventName, UnityAction listener)
    {
        if (eventName==null)
        {
            return;
        }

        UnityEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void TriggerEvent(string eventName)
    {
        if(eventName==null||eventName=="")
        {
            Debug.Log("Empty event name");
            return;
        }

        UnityEvent thisEvent = null;

        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            if(thisEvent==null)
            {
                Debug.Log("Null event");
                return;
            }
            thisEvent.Invoke();
        }
    }
}
