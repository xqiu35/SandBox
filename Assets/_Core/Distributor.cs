using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distributor : MonoBehaviour {

    [Range(1, 100)]
    public float radius = 1f;
    public float offSetY = 1f;
    public int number = 0;
    public GameObject targetObject;
    public int layerMask = Physics.DefaultRaycastLayers;
    public bool autoDistribute = false;

    void Start()
    {
        layerMask = 1 << layerMask;
        if (autoDistribute)
        {
            Distribute();
        }
    }

    public void setNumber(int number)
    {
        this.number = number;
    }

    public void setOffset(float offSet)
    {
        this.offSetY = offSet;
    }

    public void setRadius(float radius)
    {
        this.radius = radius;
    }

    public void setTargetObject(GameObject obj)
    {
        targetObject = obj;
    }

    public void setAutoDistribute(bool auto)
    {
        autoDistribute = auto;
    }

    public void setLayMask(int mask)
    {
        layerMask = 1 << mask;
    }

    public void Distribute()
    {
        for (int i = 0; i < number; i++)
        {
            Vector3 position = GetDistributePosition();
            if (position != Vector3.zero)
            {
                GameObject o = Instantiate(targetObject, position, Quaternion.identity);
                o.transform.parent = this.transform;
            }
        }
    }

    Vector3 GetDistributePosition()
    {
        Vector3 position = new Vector3();
        float startTime = Time.realtimeSinceStartup;
        bool test = false;
        while (test == false)
        {
            Vector3 positionRaw = Random.insideUnitCircle * radius;
            position = new Vector3(positionRaw.x, offSetY, positionRaw.y);
            position += transform.position;
            Vector3 halfExt = new Vector3(targetObject.transform.localScale.x / 2f,
                                            targetObject.transform.localScale.y / 2f,
                                            targetObject.transform.localScale.z / 2f);
            test = !Physics.CheckBox(position, halfExt, Quaternion.identity,layerMask);
            if (Time.realtimeSinceStartup - startTime > 0.5f)
            {
                Debug.Log("Time out placing Minion!");
                return Vector3.zero;
            }
        }
        return position;
    }
}
