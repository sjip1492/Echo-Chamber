using System.Collections.Generic;
using UnityEngine;

public class SpheresManager : PECModel
{
    public List<GameObject> spheres = new List<GameObject>();
    public GameObject spherePrefab;

    private new void Awake()
    {
        base.Awake();
        spheres = new List<GameObject>();
        spherePrefab = Resources.Load("Prefabs/Sphere") as GameObject;
    }

    public void LiveUpdateSpheres(Dictionary<int, SphereType> sphereTypes)
    {
        foreach (var sphereObject in spheres)
        {
            Sphere sphere = sphereObject.GetComponent<Sphere>();
            SphereType newSphereType = sphereTypes[sphere.sphereTypeId];
            sphere.Init(newSphereType);
        }
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
