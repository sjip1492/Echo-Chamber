using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscSendController : PECController
{
    public OscManager oscManager;
    public SurfaceController surfaceController;

    // Update is called once per frame
    void Update()
    {
        SendSpherePositionsOsc();
    }

    private void Start()
    {
        oscManager = FindObjectOfType<OscManager>();
        surfaceController = FindObjectOfType<SurfaceController>();
    }

    public override void OnNotification(string p_event_path, params object[] p_data)
    {
        base.OnNotification(p_event_path, p_data);

        switch (p_event_path)
        {
            case Notification.RoomInfoGetOsc:
                Debug.Log("Received Osc message: " + Notification.RoomInfoGetOsc);
                SendRoomInfoOsc();
                break;

            default:
                break;
        }
    }


    void SendSpherePositionsOsc()
    {
        List<OscMessage> sphere_pos_msgs = GetSpherePositionOSC();

        for (var id = 0; id < sphere_pos_msgs.Count; id++)
        {
            oscManager.osc.Send(sphere_pos_msgs[id]);
        }
    }

    public List<OscMessage> GetSpherePositionOSC()
    {
        List<Vector3> sphere_positions = FindObjectOfType<SpheresManager>().GetSpherePositions();
        List<OscMessage> sphere_position_messages = new List<OscMessage>();

        for (var id = 0; id < sphere_positions.Count; id++)
        {
            OscMessage pos_msg = new OscMessage();
            pos_msg.address = "/" + id + "/location";

            Vector3 pos = sphere_positions[id];

            pos_msg.values.Add(pos.x);
            pos_msg.values.Add(pos.y);
            pos_msg.values.Add(pos.z);

            sphere_position_messages.Add(pos_msg);
        }

        return sphere_position_messages;
    }

    public void SendRoomInfoOsc()
    {
        int numSurfaces = surfaceController.GetNumSurfaces();
        OscMessage numSurfaceInfoMessage = new OscMessage();

        numSurfaceInfoMessage.address = "/num_surfaces";

        numSurfaceInfoMessage.values.Add(numSurfaces);

        oscManager.osc.Send(numSurfaceInfoMessage);
    }
}
