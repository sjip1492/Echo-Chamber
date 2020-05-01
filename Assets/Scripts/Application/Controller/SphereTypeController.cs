using System.Text;

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

        StringBuilder audio_file = new StringBuilder();

        // reading audio file string from OscMessage
        for (int char_index = 3; char_index < message.values.Count; char_index++)
        {
            char af_char = (char)message.GetInt((int)char_index);
            audio_file.Append(af_char);
        }

        SphereType sphereType = new SphereType(id, scale, bounciness, audio_file.ToString());

        return sphereType;
    }
}
