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
            case Notification.SphereCollision:
                Debug.Log("Collision detected: " + Notification.SphereCollision);
                break;

            default:
                break;
        }
    }

    public int GetNumSurfaces()
    {
        return surfacesManager.surfaces.Count;
    }
}
