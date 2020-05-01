using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// describes the view and its features

// Can get data from Models in order to represent up-to-date game state to the user.
// For example, a View method player. Run() can internally use model.speed to manifest the player abilities.
// Should never mutate Models.
// Strictly implements the functionalities of its class. For example:
// A PlayerView should not implement input detection or modify the Game State.
// A View should act as a black box that has an interface and notifies of important events.
// Does not store core data (like speed, health, lives,…).

public class PECView : PECElement
{
    public GameObject[] cameras;

    private void Start()
    {
        cameras = GameObject.FindGameObjectsWithTag("camera");
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //app.Notify(Notification.BallHitGround, this);
    //}

}
