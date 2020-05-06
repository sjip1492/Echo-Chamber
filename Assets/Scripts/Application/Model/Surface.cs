using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surface: PECModel
{
    public int id;
    public float staticFriction;
    public float dynamicFriction;
    public float bounciness;
    public BoxCollider boxCollider;

    private new void Awake()
    {
        base.Awake();
        boxCollider = gameObject.GetComponent<BoxCollider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        app.Notify(Notification.SphereCollision, collision);
    }

    public void Init()
    {
        boxCollider.sharedMaterial.staticFriction = 0.5f;
        boxCollider.sharedMaterial.dynamicFriction = 0.5f;
        boxCollider.sharedMaterial.bounciness = 0.5f;
    }

    public void UpdateStaticFriction(float staticFriction)
    {
        boxCollider.sharedMaterial.staticFriction = staticFriction;
    }

    public void UpdateDynamicFriction(float dynamicFriction)
    {
        boxCollider.sharedMaterial.dynamicFriction = dynamicFriction;
    }

    public void UpdateBounciness(float bounciness)
    {
        boxCollider.sharedMaterial.bounciness = bounciness;
    }

}
