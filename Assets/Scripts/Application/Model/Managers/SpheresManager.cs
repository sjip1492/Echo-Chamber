using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpheresManager : PECModel
{
    public List<GameObject> spheres = new List<GameObject>();
    public GameObject spherePrefab;

    private void Awake()
    {
        base.Awake();
        spheres = new List<GameObject>();
        spherePrefab = Resources.Load("Prefabs/Sphere") as GameObject;
    }

    public List<Vector3> GetSpherePositions()
    {
        List<Vector3> sphere_locations = new List<Vector3>();

        foreach (var sphere in spheres)
        {
            sphere_locations.Add(sphere.transform.position);
        }

        return sphere_locations;
    }
}
