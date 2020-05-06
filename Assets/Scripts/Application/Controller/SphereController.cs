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
                SetRecentSphereTypeId(((OscMessage)p_data[0]).GetInt(0));
                break;

            case Notification.SphereTypeRecentIdUpdateOsc:
                app.Notify(Notification.Log, Notification.SphereTypeRecentIdUpdateOsc);
                SetRecentSphereTypeId(((OscMessage)p_data[0]).GetInt(0));
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

    void SetRecentSphereTypeId(int id)
    {
        if (sphereTypesManager.SphereTypeExists(id))
        {
            recentSphereTypeId = id;
        }
    }

    SphereType GetRecentSphereType()
    {
        SphereType sphereType;

        if (recentSphereTypeId == -1)
        {
            sphereType = new SphereType();
            sphereTypesManager.UpdateSphereType(sphereType);
            SetRecentSphereTypeId(sphereType.id);
        }
        else
        {
            sphereType = sphereTypesManager.GetSphereType(recentSphereTypeId);
        }

        return sphereType;
    }

    void ShootSphere(float speed)
    {
        GameObject sphere = GenerateSphere();

        DisableCameraCollision(sphere);

        sphere.GetComponent<Sphere>().ShootSphere(speed);
    }

    void DisableCameraCollision(GameObject sphereObject)
    {
        foreach (var cam in FindObjectOfType<PECView>().cameras)
        {
            Physics.IgnoreCollision(sphereObject.GetComponent<Collider>(), cam.GetComponent<Collider>());
        }
    }

    GameObject GenerateSphere()
    {
        SphereType recentSphereType = GetRecentSphereType();
        GameObject newSphere = InstantiateNewSphere(recentSphereType);
        spheresManager.spheres.Add(newSphere);

        return newSphere;
    }

    GameObject InstantiateNewSphere(SphereType sphereType)
    {
        // get camera/player position
        Vector3 position = playerController.player.gameObject.transform.position;

        // instantiate sphere game object at camera position
        GameObject sphereObject = (GameObject)Instantiate(spheresManager.spherePrefab, position, gameObject.transform.rotation);

        // initialize sphere script
        sphereObject.GetComponent<Sphere>().Init(sphereType);

        return sphereObject;
    }

    void DeleteSphere()
    {
        int last_sphere = spheresManager.spheres.Count - 1;

        if (last_sphere > -1)
        {
            (spheresManager.spheres[last_sphere]).GetComponent<Sphere>().DestroySphere();
            spheresManager.spheres.RemoveAt(last_sphere);
        }
    }
}
