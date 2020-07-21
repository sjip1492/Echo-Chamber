using System.Collections.Generic;
using UnityEngine;
using JackAudio;

public class SurfacesManager : PECModel
{
    public List<Surface> surfaces = new List<Surface>();
    int NumChannelSends = 2;

    private new void Awake()
    {
        base.Awake();
        SetSurfaces();
        SetJackMultiplexerOuts();
    }

    void SetJackMultiplexerOuts()
    {
        JackMultiplexer jackMultiplexer = FindObjectOfType<JackMultiplexer>();
        jackMultiplexer.OUTPUTS = surfaces.Count * NumChannelSends;
    }

    void SetSurfaces()
    {
        GameObject[] surfaceObjects = GameObject.FindGameObjectsWithTag("surface");

        for (int i = 0; i < surfaceObjects.Length; i++)
        {
            if (surfaceObjects[i].GetComponent<Surface>() == null)
            {
                surfaceObjects[i].AddComponent<Surface>();
            }

            Surface surface = surfaceObjects[i].GetComponent<Surface>();
            surface.id = i;
            surface.Init();
            surfaces.Add(surface);
        }
    }
}
