using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// base class for all elements in this application
public class PECElement : MonoBehaviour
{
    public PECApplication app;

    // Gives access to the application and all instances.
    public virtual void Awake()
    {
        app = FindObjectOfType<PECApplication>();
    }
}

// entry point
public class PECApplication: MonoBehaviour
{
    // references to the root instances of the MVC
    public PECModel model;
    public PECController controller;
    public PECView view;

    public void Awake()
    {
        PECModel[] models = FindObjectsOfType<PECModel>();
        foreach (PECModel m in models)
        {
            if (m.GetType().BaseType == typeof(PECElement))
            {
                model = m;
            }
        }

        PECController[] controllers = FindObjectsOfType<PECController>();
        foreach (PECController c in controllers)
        {
            if (c.GetType().BaseType == typeof(PECElement))
            {
                controller = c;
            }
        }

        PECView[] views = FindObjectsOfType<PECView>();
        foreach (PECView v in views)
        {
            if (v.GetType().BaseType == typeof(PECElement))
            {
                view = v;
            }
        }
    }

    // iterates all controllers and delegates the notification data
    // this method is easily found as every class in "PECElement" has an "app" instance
    public void Notify(string p_event_path, params object[] p_data)
    {
        PECController[] controllers = controller.GetAllControllers();

        foreach (PECController c in controllers)
        {
            if (c != controller) {
                c.OnNotification(p_event_path, p_data);
            }
        }
	}

	// Fetches all scene Controllers.
	public PECController[] GetAllControllers()
	{
        // TODO: faster way to access controllers? use singleton pattenr or smth?
        // TODO: load all objects found this way into the application beforehand
		return FindObjectsOfType<PECController>();
	}

}
