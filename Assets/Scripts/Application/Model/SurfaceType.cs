using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfaceType
{
    public int id;
    public float dynamicFriction;
    public float staticFriction;
    public float bounciness;

    public SurfaceType(int id, float dynamicFriction, float staticFriction, float bounciness)
    {
        this.id = id;
        this.dynamicFriction = dynamicFriction;
        this.staticFriction = staticFriction;
        this.bounciness = bounciness;
    }
}

