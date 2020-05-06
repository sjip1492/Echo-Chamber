using System.Collections.Generic;

public class SphereTypesManager : PECModel
{
    private Dictionary<int, SphereType> sphereTypes = new Dictionary<int, SphereType>();

    public void UpdateSphereType(SphereType sphereType)
    {
        sphereTypes[sphereType.id] = sphereType;
    }

    public Dictionary<int, SphereType> GetSphereTypes()
    {
        return sphereTypes;
    }

    public bool SphereTypeExists(int id)
    {
        return sphereTypes.ContainsKey(id);
    }

    public SphereType GetSphereType(int id)
    {
        return sphereTypes[id];
    }
}
