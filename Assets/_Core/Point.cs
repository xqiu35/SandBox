using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Point : MonoBehaviour {

    public string pointName;

    Point()
    {
        if(pointName == null|| pointName == "")
        {
            pointName = "default";
        }
    }

    public void setName(string thisName)
    {
        this.pointName = thisName;
    }

    public string getName()
    {
        return this.pointName;
    }
}
