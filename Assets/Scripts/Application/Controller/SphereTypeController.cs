using System.Text;
using System.IO;
using UnityEngine;


public class SphereTypeController : PECController
{
    private SphereTypesManager sphereTypesManager;
    private SpheresManager spheresManager;
    public bool sphereTypeLiveUpdate;

    private new void Awake()
    {
        base.Awake();
        sphereTypeLiveUpdate = false;
    }

    private void Start()
    {
        sphereTypesManager = FindObjectOfType<SphereTypesManager>();
        spheresManager = FindObjectOfType<SpheresManager>();
    }

    public override void OnNotification(string p_event_path, params object[] p_data)
    {
        base.OnNotification(p_event_path, p_data);

        switch (p_event_path)
        {
            case Notification.SphereTypeUpdateOsc:
                UpdateSphereTypeOsc((OscMessage)p_data[0]);
                break;

            case Notification.SphereTypeLiveUpdateOsc:
                app.Notify(Notification.Log, Notification.SphereTypeLiveUpdateOsc);
                SetSphereTypeLiveUpdate((OscMessage)p_data[0]);
                break;

            case Notification.SphereTypeLiveUpdate:
                SetSphereTypeLiveUpdateFlag((int)p_data[0]);
                break;

            default:
                break;
        }
    }

    public void UpdateSphereTypeOsc(OscMessage message)
    {
        SphereType sphereType = DecodeOscMessage_UpdateSphereType(message);
        sphereTypesManager.UpdateSphereType(sphereType);

        if (sphereTypeLiveUpdate)
            spheresManager.LiveUpdateSpheres(sphereTypesManager.GetSphereTypes());
    }

    public void SetSphereTypeLiveUpdate(OscMessage message)
    {
        int flag = message.GetInt(0);
        SetSphereTypeLiveUpdateFlag(flag);
    }

    public void SetSphereTypeLiveUpdateFlag(int flag)
    {
        if (flag == 0)
        {
            sphereTypeLiveUpdate = false;
        }
        else
        {
            sphereTypeLiveUpdate = true;
        }

    }

    SphereType DecodeOscMessage_UpdateSphereType(OscMessage message)
    {
        // TODO: clean up and separate

        int id = message.GetInt(0);
        float scale = message.GetFloat(1);
        float bounciness = message.GetFloat(2);
        float mass = message.GetFloat(3);

        // reading audio file string from OscMessage
        string audioFile = GetStringFromBinary(4, message);

        SphereType sphereType;

        try
        {
            sphereType = new SphereType(id, scale, bounciness, audioFile, mass);
        }
        catch
        {
            // return default sphere
            app.Notify(Notification.LogError, "Sphere type not updated.");
            sphereType = new SphereType();
        }

        return sphereType;
    }

    string GetStringFromBinary(int startIndex, OscMessage binaryMessage)
    {
        StringBuilder stringBuilder = new StringBuilder();

        // build string from the rest of the messages
        for (int char_index = startIndex; char_index < binaryMessage.values.Count; char_index++)
        {
            char af_char = (char)binaryMessage.GetInt((int)char_index);
            stringBuilder.Append(af_char);
        }

        return stringBuilder.ToString();
    }
}
