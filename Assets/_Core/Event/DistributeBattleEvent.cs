using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Distributor))]
public class DistributeBattleEvent : GameEvent {

    private Distributor distributor;
    private SphereCollider area;

    protected override void onEnable()
    {
        this.setEventName("DistributeBattle");
        this.setEventAction(new UnityAction(Distribute));
    }

    // Use this for initialization
    void Start () {
        area = GetComponent<SphereCollider>();
        distributor = GetComponent<Distributor>();

        distributor.setRadius(area.radius);
    }

    protected override void onTriggerEnter(Collider other)
    {
       /* if(other.GetComponent<Combatant>())
        {
            setConditionMeet(true);
        }*/
    }

    protected override void onTriggerExit(Collider other)
    {
        /*if (other.GetComponent<Combatant>())
        {
            setConditionMeet(false);
        }*/
    }

    private void Distribute()
    {
        distributor.Distribute();
    }
}
