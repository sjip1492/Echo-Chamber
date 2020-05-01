using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surface: PECModel
{
    public int id;

    private void OnCollisionEnter(Collision collision)
    {
        app.Notify(Notification.SphereCollision, collision);
    }
}
