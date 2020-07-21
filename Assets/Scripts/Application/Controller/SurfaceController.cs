using UnityEngine;

public class SurfaceController : PECController
{
    SurfacesManager surfacesManager;

    private void Start()
    {
        surfacesManager = FindObjectOfType<SurfacesManager>();
    }

    public override void OnNotification(string p_event_path, params object[] p_data)
    {
        base.OnNotification(p_event_path, p_data);

        switch (p_event_path)
        {
            case Notification.SurfaceTypeUpdateOsc:
                app.Notify(Notification.Log, Notification.SurfaceTypeUpdateOsc);
                UpdateSurfaceTypeOsc((OscMessage)p_data[0]);
                break;

            default:
                break;
        }
    }

    public int GetNumSurfaces()
    {
        return surfacesManager.surfaces.Count;
    }

    void InitSurfaces()
    {
        foreach (Surface surface in surfacesManager.surfaces)
        {
            surface.Init();
        }
    }

    void UpdateSurfaceType(int id, float dynamicFriction, float staticFriction, float bounciness)
    {
        if (id <= (surfacesManager.surfaces.Count - 1) && id > -1)
        {
            Surface surface = surfacesManager.surfaces[id];

            surface.UpdateDynamicFriction(dynamicFriction);
            surface.UpdateStaticFriction(staticFriction);
            surface.UpdateBounciness(bounciness);
         } else
        {
            app.Notify(Notification.LogError, "Invalid surface type ID.");
        }
    }

    void UpdateSurfaceTypeOsc(OscMessage message)
    {
        int id = message.GetInt(0);
        float dynamicFriction = message.GetFloat(1);
        float staticFriction = message.GetFloat(2);
        float bounciness = message.GetFloat(3);

        UpdateSurfaceType(id, dynamicFriction, staticFriction, bounciness);
    }
}
