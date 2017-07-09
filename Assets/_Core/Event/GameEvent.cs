using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public abstract class GameEvent : MonoBehaviour {

    protected string thisName;
    protected UnityAction thisAction;
    protected bool thisConditionMeet;

    public TriggerTime triggerTime;
    public TriggerType triggetType;

    public void setEventName(string eventName)
    {
        thisName = eventName;
    }

    public void setEventAction(UnityAction eventAction)
    {
        thisAction = eventAction;
    }

    public void setConditionMeet(bool meet)
    {
        thisConditionMeet = meet;
    }

    void Start()
    {
        if(triggerTime == TriggerTime.OnStart)
        {
            start();
            if(triggetType == TriggerType.Auto)
            {
                EventManager.TriggerEvent(thisName);
            }
            else if(triggetType == TriggerType.Condition)
            {
                if(thisConditionMeet)
                {
                    EventManager.TriggerEvent(thisName);
                }
            }
        }
    }

    void Update()
    {
        if (triggerTime == TriggerTime.OnUpdate)
        {
            update();
            if (triggetType == TriggerType.Auto)
            {
                EventManager.TriggerEvent(thisName);
            }
            else if (triggetType == TriggerType.Condition)
            {
                if (thisConditionMeet)
                {
                    EventManager.TriggerEvent(thisName);
                }
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(triggerTime == TriggerTime.OnCollisionEnter)
        {
            onCollisionEnter(other);
            if (triggetType == TriggerType.Auto)
            {
                EventManager.TriggerEvent(thisName);
            }
            else if (triggetType == TriggerType.Condition)
            {
                if (thisConditionMeet)
                {
                    EventManager.TriggerEvent(thisName);
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (triggerTime == TriggerTime.OnTriggerEnter)
        {
            onTriggerEnter(other);
            if (triggetType == TriggerType.Auto)
            {
                EventManager.TriggerEvent(thisName);
            }
            else if (triggetType == TriggerType.Condition)
            {
                if (thisConditionMeet)
                {
                    EventManager.TriggerEvent(thisName);
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (triggerTime == TriggerTime.OnTriggerExit)
        {
            onTriggerExit(other);
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (triggerTime == TriggerTime.OnCollisionExit)
        {
            onCollisionExit(other);
        }
    }

    void OnDisable()
    {
        onDisable();
        EventManager.StopListening(thisName, thisAction);
    }

    void OnEnable()
    {
        onEnable();
        EventManager.StartListening(thisName, thisAction);
    }

    protected abstract void onEnable();
    protected virtual void onDisable() { }
    protected virtual void start() { }
    protected virtual void update() { }

    protected virtual void onCollisionEnter(Collision other) { }
    protected virtual void onCollisionExit(Collision other) { }

    protected virtual void onTriggerEnter(Collider other) { }
    protected virtual void onTriggerExit(Collider other) { }
    
}
