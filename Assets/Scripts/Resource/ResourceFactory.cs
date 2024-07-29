using UnityEngine;

public class ResourceFactory : MonoBehaviour
{
    public ResourceData CreateResource(string resourceName, int amount, int capacity, GameObject resourcePrefab, Vector3Int position)
    {
        ResourceData newResource = ScriptableObject.CreateInstance<ResourceData>();
        newResource.resourceName = resourceName;
        newResource.amount = amount;
        newResource.capacity = capacity;
        newResource.resourcePrefab = resourcePrefab;
        newResource.position = position;

        return newResource;
    }
}
