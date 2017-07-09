using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnEvent : GameEvent
{
    public GameObject spawnObject;
    public Point spawnPoint;

    void Spawn()
    {
        Instantiate(spawnObject, spawnPoint.transform.position, Quaternion.identity);
    }

    protected override void onEnable()
    {
        this.setEventName("Spawn");
        this.setEventAction(new UnityAction(Spawn));
    }
}
