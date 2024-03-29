﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ASSIGN TO VIEW/UI
public class OscReceiveController : PECController
{
    OSC osc;
    OscManager oscManager;

    // Start is called before the first frame update
    private void Start()
    {
        // set up Address Handlers
        oscManager = FindObjectOfType<OscManager>();
        osc = oscManager.osc;

        osc.SetAddressHandler("/sphere_type", OnSphereTypeUpdate);
        osc.SetAddressHandler("/curr_sphere_type_id", OnRecentSphereTypeIdUpdate);
        osc.SetAddressHandler("/sphere_type_live_update", OnSphereTypeLiveUpdate);
        osc.SetAddressHandler("/surface_type", OnReceiveSurfaceType);
        osc.SetAddressHandler("/get_room_info", OnReceiveGetRoomInfo);
        osc.SetAddressHandler("/shoot_speed", OnReceiveShootSpeed);
        osc.SetAddressHandler("/shoot_sphere", OnReceiveShootSphere);
        osc.SetAddressHandler("/delete_sphere", OnReceiveDeleteSphere);
        osc.SetAddressHandler("/gravity", OnReceiveGravity);
    }

    public void OnSphereTypeUpdate(OscMessage message)
    {
        app.Notify(Notification.SphereTypeUpdateOsc, message);
    }

    public void OnSphereTypeLiveUpdate(OscMessage message)
    {
        app.Notify(Notification.SphereTypeLiveUpdateOsc, message);
    }

    public void OnRecentSphereTypeIdUpdate(OscMessage message)
    {
        app.Notify(Notification.SphereTypeRecentIdUpdateOsc, message);
    }

    public void OnReceiveSurfaceType(OscMessage message)
    {
        app.Notify(Notification.SurfaceTypeUpdateOsc, message);
    }

    public void OnReceiveGetRoomInfo(OscMessage message)
    {
        app.Notify(Notification.RoomInfoGetOsc, message);
    }

    public void OnReceiveShootSpeed(OscMessage message)
    {
        app.Notify(Notification.PlayerShootSpeedOsc, message);
    }

    public void OnReceiveShootSphere(OscMessage message)
    {
        app.Notify(Notification.ShootSphere, message);
    }

    public void OnReceiveDeleteSphere(OscMessage message)
    {
        app.Notify(Notification.DeleteSphere, message);
    }

    public void OnReceiveGravity(OscMessage message)
    {
        app.Notify(Notification.GravityUpdateOsc, message);
    }
}
