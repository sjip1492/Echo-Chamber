using System.Text;
using System.IO;
using UnityEngine;

public class SphereTypeController : PECController
{
    private SphereTypesManager sphereTypesManager;
    public bool sphereTypeLiveUpdate;
    private SphereController sphereController;

    private void Awake()
    {
        base.Awake();
        sphereTypeLiveUpdate = false;
    }

    private void Start()
    {
        sphereTypesManager = FindObjectOfType<SphereTypesManager>();
        sphereController = FindObjectOfType<SphereController>();
    }

    public override void OnNotification(string p_event_path, params object[] p_data)
    {
        base.OnNotification(p_event_path, p_data);

        switch (p_event_path)
        {
            case Notification.SphereTypeUpdateOsc:
                UpdateSphereTypeOsc((OscMessage)p_data[0]);
                break;

            case Notification.SphereTypeUpdate:
                SphereType sphereType = (SphereType)p_data[0];
                UpdateSphereType(sphereType);
                break;

            case Notification.SphereTypeLiveUpdateOsc:
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
        UpdateSphereType(sphereType);
    }

    public void UpdateSphereType(SphereType sphereType)
    {
        sphereTypesManager.sphereTypes[sphereType.id] = sphereType;

        if (sphereTypeLiveUpdate)
        {
            sphereController.LiveUpdateSpheres();
        }
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
        int id = message.GetInt(0);
        float scale = message.GetFloat(1);
        float bounciness = message.GetFloat(2);
        float mass = message.GetFloat(3);

        // reading audio file string from OscMessage
        string audioFile = GetStringFromBinary(message);
        CheckValidAudioFile(audioFile);

        SphereType sphereType;

        if (CheckValidAudioFile(audioFile)) {
            sphereType = new SphereType(id, scale, bounciness, audioFile, mass);
        } else {
            sphereType = new SphereType();
        }

        return sphereType;
    }

    string GetStringFromBinary(OscMessage binaryMessage)
    {
        StringBuilder stringBuilder = new StringBuilder();

        for (int char_index = 4; char_index < binaryMessage.values.Count; char_index++)
        {
            char af_char = (char)binaryMessage.GetInt((int)char_index);
            stringBuilder.Append(af_char);
        }
        return stringBuilder.ToString();
    }

    bool CheckValidAudioFile(string audioFilePath)
    {
        if (!File.Exists(audioFilePath))
        {
            app.Notify(Notification.Error, "Error: Audio file does not exist.");
            return false;
        }

        string fileExtension = Path.GetExtension(audioFilePath);

        if (!(fileExtension.Equals(".ogg") || fileExtension.Equals(".mp3") || fileExtension.Equals(".wav"))) {
            app.Notify(Notification.Error, "Error: Unsupported audio file type.");
            return false;
        }

        return true;
    }
}
