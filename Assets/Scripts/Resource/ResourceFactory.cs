using UnityEngine;

namespace Mindactory
{
    public class ResourceFactory : IResourceFactory
    {
        public ResourceData CreateResource(string resourceName, int amount, int capacity, GameObject prefab, Vector2 position)
        {
            ResourceData newResource = ScriptableObject.CreateInstance<ResourceData>();
            newResource.ResourceName = resourceName;
            newResource.Amount = amount;
            newResource.Capacity = capacity;
            newResource.ResourcePrefab = prefab;
            newResource.Position = position;
            return newResource;
        }
    }
}
