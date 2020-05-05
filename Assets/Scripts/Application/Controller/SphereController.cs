using UnityEngine;

public class SphereController : PECController
{
    private int recentSphereTypeId = -1;

    protected SphereTypesManager sphereTypesManager;
    protected SpheresManager spheresManager;
    protected PlayerController playerController;

    private void Start()
    {
        sphereTypesManager = FindObjectOfType<SphereTypesManager>();
        spheresManager = FindObjectOfType<SpheresManager>();
        playerController = FindObjectOfType<PlayerController>();
    }

    public override void OnNotification(string p_event_path, params object[] p_data)
    {
        base.OnNotification(p_event_path, p_data);

        switch (p_event_path)
        {
            case Notification.SphereTypeUpdateOsc:
                app.Notify(Notification.Log, Notification.SphereTypeUpdateOsc);
                UpdateRecentSphereTypeIdOsc((OscMessage)p_data[0]);
                break;

            case Notification.SphereTypeRecentIdUpdateOsc:
                app.Notify(Notification.Log, Notification.SphereTypeRecentIdUpdateOsc);
                UpdateRecentSphereTypeIdOsc((OscMessage)p_data[0]);
                break;

            case Notification.SphereTypeRecentIdUpdate:
                app.Notify(Notification.Log, Notification.SphereTypeRecentIdUpdate);
                int sphereTypeId = ((SphereType)p_data[0]).id;
                SetRecentSphereTypeId(sphereTypeId);
                break;

            case Notification.ShootSphere:
                app.Notify(Notification.Log, Notification.ShootSphere);
                ShootSphere(playerController.player.shootSpeed);
                break;

            case Notification.DeleteSphere:
                app.Notify(Notification.Log, Notification.DeleteSphere);
                DeleteSphere();
                break;

            default:
                break;
        }
    }

    public void UpdateRecentSphereTypeIdOsc(OscMessage message)
    {
        int id = DecodeOscMessage_UpdateRecentSphereTypeId(message);
        SetRecentSphereTypeId(id);
    }

    public void SetRecentSphereTypeId(int id)
    {
        recentSphereTypeId = id;
    }

    SphereType GetRecentSphereType()
    {
        SphereType sphereType;

        if (recentSphereTypeId > sphereTypesManager.sphereTypes.Count || recentSphereTypeId == -1)
        {
            SetRecentSphereTypeId(1);
            sphereType = new SphereType();
        }
        else
        {
            sphereType = sphereTypesManager.sphereTypes[recentSphereTypeId];
        }

        return sphereType;
    }

    int DecodeOscMessage_UpdateRecentSphereTypeId(OscMessage message)
    {
        return message.GetInt(0);
    }

    public void ShootSphere(float speed)
    {
        GameObject sphere = GenerateSphere();
        DisableCameraCollision(sphere);
        // TODO: refactor the shoot sphere to take place inside player controller?
        sphere.GetComponent<Sphere>().ShootSphere(playerController.player.shootSpeed);
    }

    void DisableCameraCollision(GameObject sphereObject)
    {
        foreach (var cam in FindObjectOfType<PECView>().cameras)
        {
            Physics.IgnoreCollision(sphereObject.GetComponent<Collider>(), cam.GetComponent<Collider>());
        }
    }

    public GameObject GenerateSphere()
    {
        SphereType recentSphereType = GetRecentSphereType();
        GameObject newSphere = InstantiateNewSphere(recentSphereType);
        spheresManager.spheres.Add(newSphere);

        return newSphere;
    }

    public GameObject InstantiateNewSphere(SphereType sphereType)
    {
        // get camera/player position
        Vector3 position = playerController.player.gameObject.transform.position;

        // instantiate sphere game object at camera position
        GameObject sphereObject = (GameObject)Instantiate(spheresManager.spherePrefab, position, gameObject.transform.rotation);

        // initialize sphere script
        Sphere sphere = sphereObject.GetComponent<Sphere>();
        sphere.sphereType = sphereType;
        sphere.Init();

        return sphereObject;
    }

    public void DeleteSphere()
    {
        int last_sphere = spheresManager.spheres.Count - 1;

        if (last_sphere > -1)
        {
            (spheresManager.spheres[last_sphere]).GetComponent<Sphere>().DestroySphere();
            spheresManager.spheres.RemoveAt(last_sphere);
        }
    }

    public void UpdateSphereTypeComponent(Sphere sphere, SphereType sphereType)
    {
        sphere.sphereType.scale = sphereType.scale;
        sphere.sphereType.bounciness = sphereType.bounciness;
        sphere.sphereType.mass = sphereType.mass;
        sphere.sphereType.audio_file = sphereType.audio_file;
    }

    public void LiveUpdateSpheres()
    {
        foreach (var sphereObject in spheresManager.spheres)
        {
            Sphere sphere = sphereObject.GetComponent<Sphere>();
            SphereType newSphereType = sphereTypesManager.sphereTypes[sphere.sphereType.id];
            UpdateSphereTypeComponent(sphere, newSphereType);
            sphere.Init();
        }
    }
}
