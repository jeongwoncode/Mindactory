using UnityEngine;

public class ResourceFactory
{
    public GameObject CreateResource(ResourceData resourceData, Vector3 position)
    {
        return Object.Instantiate(resourceData.resourcePrefab, position, Quaternion.identity);
    }
}
