using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// controls the app workflow

// Do not store core data.
// Can sometimes filter notifications from undesired Views.
// Update and use the Model’s data.
// Manages Unity’s scene workflow.

public class PECController : PECElement
{
	public virtual void OnNotification(string p_event_path, params object[] p_data)
    {
    }

    public PECController[] GetAllControllers()
    {
        // TODO : programmatically set the controllers?
        return FindObjectsOfType<PECController>();
    }
}
