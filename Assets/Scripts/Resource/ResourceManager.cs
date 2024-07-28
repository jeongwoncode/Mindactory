using System.Collections.Generic;
using UnityEngine;

namespace Mindactory
{
    public class ResourceManager : MonoBehaviour
    {
        public List<ResourceData> resources = new List<ResourceData>();

        public ResourceData GetResourceAtPosition(Vector2 position)
        {
            foreach (var resource in resources)
            {
                if (resource.Position == position)
                {
                    return resource;
                }
            }
            return null;
        }

        public void CollectResource(ResourceData resource)
        {
            resource.Amount -= 1;
            if (resource.Amount <= 0)
            {
                resources.Remove(resource);
                Destroy(resource.ResourcePrefab);
            }
        }
    }
}
